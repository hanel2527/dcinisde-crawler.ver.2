using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System;
using System.Linq;
using hap = HtmlAgilityPack;
using njson = Newtonsoft.Json;


namespace DcCrawler
{
    enum userStatus
    {
        error = 0,
        fluidNick = 1,
        fixedNick = 2,
        halfFixedNick = 3,
        info = 16,
        used = 31,
        notUsed = 32
    }
    [Serializable]
    public class UserInfo
    {
        //Dictionary value => count, replyNum, gallCount, gallRecommend
        public string Nick, IdorIp;
        public int status, count, replyNum, gallCount, gallRecommend;
        public UserInfo() { }
        protected void SetUserInfo(UserInfo userInfo)
        {
            this.Nick = userInfo.Nick; this.IdorIp = userInfo.IdorIp;
            this.status = userInfo.status;
        }
        public UserInfo(string Nick) { this.Nick = Nick; }
        public UserInfo(string Nick, string IdorIp, int status)
        {
            this.Nick = Nick; this.IdorIp = IdorIp; this.status = status;
        }

        public void setFluidNick(string IdorIp)
        {
            this.IdorIp = IdorIp;
            this.status = (int)userStatus.fluidNick;
        }
        public void setFixedNick(string IdorIp)
        {
            this.IdorIp = IdorIp;
            this.status = (int)userStatus.fixedNick;
        }

        //Override methods of System.Object: ToString(), Equals(Object obj), GetHashCode()
        public override string ToString()
        {
            return this.Nick + "(" + this.IdorIp + ")";
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            UserInfo userInfo = (UserInfo)obj;
            if (this.Nick.Equals(userInfo.Nick))
            {
                if (this.IdorIp.Equals(userInfo.IdorIp))
                {
                    if (this.status == userInfo.status)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
    [Serializable]
    public class UserRank
    {
        public List<UserInfo> userInfos = new List<UserInfo>();
        public int count, replyNum, gallCount, gallRecommend, status;
        public UserRank(UserInfo userInfo, int count, int replyNum, int gallCount, int gallRecommend)
        {
            status = (int)userStatus.used;
            this.userInfos.Add(userInfo);
            this.count = count; this.replyNum = replyNum; this.gallCount = gallCount; this.gallRecommend = gallRecommend;
        }
        public void NotUsed()
        {
            status = (int)userStatus.notUsed;
            this.count = 0; this.replyNum = 0; this.gallCount = 0; this.gallRecommend = 0;
        }
        public bool Update()
        {
            if (userInfos.Count == 1 || status == (int)userStatus.notUsed) return false;
            int totalCount = 0, totalReplyNum = 0, totalGallCount = 0, totalGallRecomend = 0;
            foreach (UserInfo user in userInfos)
            {
                totalCount += user.count;
                totalReplyNum += user.replyNum;
                totalGallCount += user.gallCount;
                totalGallRecomend += user.gallRecommend;
            }
            this.count = totalCount;
            this.replyNum = totalReplyNum;
            this.gallCount = totalGallCount;
            this.gallRecommend = totalGallRecomend;
            return true;
        }
        public bool IsSameUser(UserRank otherUser)
        {
            if (this.status == (int)userStatus.notUsed || otherUser.status == (int)userStatus.notUsed)
            {
                return false;
            }
            foreach (UserInfo user1 in userInfos)
            {
                foreach (UserInfo user2 in otherUser.userInfos)
                {
                    if (user1.status == user2.status)
                    {
                        if (user1.status == (int)userStatus.fixedNick)
                        {
                            if (user1.IdorIp.Equals(user2.IdorIp))
                            {
                                Console.WriteLine(user1.IdorIp + " 같다 " + user2.IdorIp);
                                return true;
                            }
                        }
                        else if (user1.status == (int)userStatus.fluidNick)
                        {
                            if (user1.Nick.Equals(user2.Nick) && user1.Nick != "ㅇㅇ")
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public string ToString(string op)
        {
            List<string> stringList = new List<string>();
            string str = "";
            bool shouldPass = false;
            if (op.Equals("IdorIp"))
            {
                if (userInfos.Count == 1)
                    return this.userInfos[0].IdorIp;
                foreach (UserInfo user in userInfos)
                {
                    shouldPass = false;
                    foreach(string temp in stringList)
                    {
                        if (temp.Equals(user.IdorIp))
                            shouldPass = true;
                    }
                    if (shouldPass)
                        continue;
                    else
                    {
                        stringList.Add(user.IdorIp);
                        str += user.IdorIp + "<br>";
                    }
                }
                return str;
            }
            else if (op.Equals("Nick"))
            {
                if (userInfos.Count == 1)
                    return this.userInfos[0].Nick;
                foreach (UserInfo user in userInfos)
                {
                    shouldPass = false;
                    foreach (string temp in stringList)
                    {
                        if (temp.Equals(user.Nick))
                            shouldPass = true;
                    }
                    if (shouldPass)
                        continue;
                    else
                    {
                        stringList.Add(user.Nick);
                        str += user.Nick + "<br>";
                    }
                }
                return str;
            }
            return "error";
        }
        public override string ToString()
        {
            if (this.status == (int)userStatus.notUsed)
            {
                return "";
            }
            else if (userInfos.Count == 1)
            {
                return userInfos[0].ToString();
            }
            else
            {
                string str = userInfos[0].ToString();
                for (int i = 1; i < userInfos.Count; i++)
                {
                    str = str + "+" + userInfos[i].ToString();
                }
                return str;
            }
        }
    }
    [Serializable]
    public class UserData : UserInfo
    {
        public int gallNum; //replyNum, gallCount, gallRecommend;
        public DateTime gallDate;
        public string subject;
        public UserData(UserInfo newUserInfo) : base()
        {
            base.SetUserInfo(newUserInfo);
        }
        public void DataInput(int gallNum, int replyNum, int gallCount, int gallRecommend, DateTime gallDate, string subject)
        {
            this.gallNum = gallNum; this.replyNum = replyNum; this.gallCount = gallCount; this.gallRecommend = gallRecommend;
            this.gallDate = gallDate; this.subject = subject;
        }

        //Override methods of System.Object: ToString(), Equals(Object obj), GetHashCode()
        public override string ToString()
        {
            return base.ToString() + " " + gallDate.ToString() + "\t" + gallNum.ToString() + "\n"
                + subject + "\t" + "댓글 수: " + replyNum + " 조회 수: " + gallCount + "추천: " + gallRecommend + "\n";
        }
        public override bool Equals(object obj)
        {
            UserData userData = (UserData)obj;
            if (userData.gallNum == this.gallNum) { return true; }
            else { return false; }
        }
        public override int GetHashCode()
        {
            return this.gallNum.GetHashCode();
        }
    }

    class Program
    {
        static void __Main__()
        {
            /*
Console.Write("파일 이름: ");
string filename = Console.ReadLine();
DataToText dtt = new DataToText(filename);
dtt.AutoUserManager();
Console.Write("저장 파일 이름?: ");
filename = Console.ReadLine();
dtt.SaveToText(filename);
Console.Write("시작 페이지?: ");
int initPage = int.Parse(Console.ReadLine());
Console.Write("끝 페이지?: ");
int endPage = int.Parse(Console.ReadLine());
Console.Write("갤 id?: ");
string gallId = Console.ReadLine();
Console.Write("마어너 갤?(y/n): ");
string str = Console.ReadLine();
bool isMinor;
if (str == "y") isMinor = true;
else isMinor = false;
GallchangrankingCrawler gcrk = new GallchangrankingCrawler(initPage, endPage, gallId, isMinor);
gcrk.Crawler();
*/
        }
    }

    public class GallchangrankingCrawler
    {
        public event EventHandler newPageHappened;
        public event EventHandler CrawlingEnded;
        public event EventHandler NewVersionUpdateExist;
        public event EventHandler ErrorOccured;

        int initPage, endPage;
        DateTime initDate, endDate;
        bool isMinor;
        public string gallId, gallName, gallUrl, version = "v2.0.8-beta";
        List<UserRank> userList = new List<UserRank>();
        //List<UserData> gallDatas = new List<UserData>();

        public GallchangrankingCrawler(int initPage, int endPage, string gallId, bool isMinor)
        {
            initDate = new DateTime(1999, 1, 1);
            endDate = DateTime.Now;
            this.initPage = initPage; this.endPage = endPage;
            this.gallId = gallId; this.isMinor = isMinor;
            if (this.isMinor) { gallUrl = "https://gall.dcinside.com/mgallery/board/lists?id=" + gallId; }
            else { gallUrl = "https://gall.dcinside.com/board/lists/?id=" + gallId; }
            GallCheck(gallUrl);
            Console.WriteLine(gallName);
        }
        public GallchangrankingCrawler(DateTime initDate, DateTime endDate, string gallId, bool isMinor, int initPage = 1)
        {
            this.initPage = initPage; this.endPage = 1000000000;
            this.initDate = initDate; this.endDate = endDate;
            this.gallId = gallId; this.isMinor = isMinor;
            if (this.isMinor) { gallUrl = "https://gall.dcinside.com/mgallery/board/lists?id=" + gallId; }
            else { gallUrl = "https://gall.dcinside.com/board/lists/?id=" + gallId; }
        }
        public GallchangrankingCrawler() { }
        public void GallCheck(string gallUrl)
        {
            var client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            string text = client.DownloadString(gallUrl);
            hap.HtmlDocument textHap = new hap.HtmlDocument();
            try
            {
                textHap.LoadHtml(text);
                this.gallName = textHap.DocumentNode.SelectSingleNode("//title").InnerText;
            }
            catch
            {
                this.gallName = "gallNotFoundException";
            }
        }
        int GetOnlyInt(string str)
        {
            Regex regex = new Regex(@"\d+");
            Match match = regex.Match(str);
            int resultInt;
            if (match.Success)
            {
                resultInt = int.Parse(match.Value);
                return resultInt;
            }
            else { return -1; }
        }
        public void UpdateChecker(string currentVersion)   //구현
        {
            string github = "https://github.com/hanel2527/dcinisde-crawler.ver.2/blob/master/versions.txt";
            var client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            string text = client.DownloadString(github);
            hap.HtmlDocument doc = new hap.HtmlDocument();
            doc.LoadHtml(text);
            hap.HtmlNode myVersions = doc.DocumentNode.
                SelectSingleNode("//table[@class='highlight tab-size js-file-line-container']");
            text = myVersions.InnerText.Trim();
            string[] versions = text.Split(new[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (NewVersionUpdateExist != null)
            {
                if (versions[0].Equals(currentVersion))
                    NewVersionUpdateExist("최신 버전입니다: " + versions[0], null);
                else
                    NewVersionUpdateExist("새로운 업데이트가 있습니다(클릭): " + versions[0], null);
            }
        }
        public void Crawler()
        {
            int previousPageGallNum = 1000000000;
            Console.WriteLine(initDate.ToString() + endDate.ToString());

            string url = gallUrl + "&page=";

            var client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            //Dictionary value => count, replyNum, gallCount, gallRecommend
            Dictionary<UserInfo, int[]> userDic = new Dictionary<UserInfo, int[]>();

            int currentPage = this.initPage;
            while (true)
            {
                string text;
                try
                {
                    text = client.DownloadString(url + currentPage.ToString());
                    if (string.IsNullOrEmpty(text))
                    {
                        continue;
                    }
                }
                catch
                {
                    continue;
                }
                 

                hap.HtmlDocument textHap = new hap.HtmlDocument();
                textHap.LoadHtml(text);

                hap.HtmlNodeCollection nicks = textHap.DocumentNode.SelectNodes("//tr[@class='ub-content us-post']");
                //Console.WriteLine(nicks.Count);
                //Console.WriteLine("==================" + currentPage.ToString() + "==================");
                try
                {
                    foreach (hap.HtmlNode nick in nicks)
                    {
                        int gallNum, replyNum, gallCount, gallRecommend;
                        DateTime gallDate; string subject;

                        gallNum = GetOnlyInt(nick.SelectSingleNode("./td[@class='gall_num']").InnerText);
                        gallDate = DateTime.ParseExact(nick.SelectSingleNode("./td[@class='gall_date']").Attributes["title"].Value,
                            "yyyy-MM-dd HH:mm:ss", null);
                        Console.WriteLine(gallNum.ToString() + " " + gallDate.ToString());
                        if (gallNum >= previousPageGallNum)
                        {
                            Console.WriteLine(previousPageGallNum.ToString() + " " + gallNum.ToString());
                            Console.WriteLine("번호 에러");
                            continue;
                        }
                        if (DateTime.Compare(gallDate, initDate) < 0 || DateTime.Compare(gallDate, endDate) > 0)
                        {
                            Console.WriteLine("날짜 에러");
                            continue;
                        }

                        hap.HtmlNode user = nick.SelectSingleNode("./td[@class='gall_writer ub-writer']");
                        UserInfo tempUserInfo = new UserInfo(user.Attributes["data-nick"].Value);
                        if (user.Attributes["data-uid"].Value == "")
                        {
                            tempUserInfo.setFluidNick(user.Attributes["data-ip"].Value);
                        }
                        else
                        {
                            tempUserInfo.setFixedNick(user.Attributes["data-uid"].Value);
                        }

                        //replyNum and subject are in <td class='gall_tit ub-word'></td>
                        hap.HtmlNode subjectNode = nick.SelectSingleNode("./td[2]");
                        try
                        {
                            if (subjectNode.Attributes["class"].Value == "gall_subject")
                            {
                                subjectNode = nick.SelectSingleNode("./td[3]");
                            }
                            subject = subjectNode.SelectSingleNode("./a[1]").InnerText;
                            if (subjectNode.SelectNodes("./a").Count == 2)
                            {
                                replyNum = GetOnlyInt(subjectNode.SelectSingleNode("./a[@class='reply_numbox']/span").InnerText);
                            }
                            else
                            {
                                replyNum = 0;
                            }
                        }
                        catch
                        {
                            subject = "NullSubjectException";
                            replyNum = 0;
                        }
                        // Console.WriteLine("댓글: " + replyNum.ToString());
                        gallCount = GetOnlyInt(nick.SelectSingleNode("./td[@class='gall_count']").InnerText);
                        gallRecommend = GetOnlyInt(nick.SelectSingleNode("./td[@class='gall_recommend']").InnerText);


                        //Dictionary value => count, replyNum, gallCount, gallRecommend
                        if (userDic.ContainsKey(tempUserInfo))
                        {
                            userDic[tempUserInfo][0] += 1;
                            userDic[tempUserInfo][1] += replyNum;
                            userDic[tempUserInfo][2] += gallCount;
                            userDic[tempUserInfo][3] += gallRecommend;
                        }
                        else
                        {
                            int[] tempInts = new int[] { 1, replyNum, gallCount, gallRecommend };
                            userDic.Add(tempUserInfo, tempInts);
                        }
                        UserData tempUserData = new UserData(tempUserInfo);
                        tempUserData.DataInput(gallNum, replyNum, gallCount, gallRecommend, gallDate, subject);
                        //gallDatas.Add(tempUserData);
                    }
                }
                catch
                {
                    if(ErrorOccured != null)
                    {
                        ErrorOccured(text, null);
                    }
                    currentPage++;
                    continue;
                }
                
                previousPageGallNum = GetOnlyInt(nicks[nicks.Count - 1].SelectSingleNode("./td[@class='gall_num']").InnerText);
                DateTime currentDate = DateTime.ParseExact(nicks[nicks.Count - 1].
                    SelectSingleNode("./td[@class='gall_date']").Attributes["title"].Value, "yyyy-MM-dd HH:mm:ss", null);
                if (currentPage >= endPage || DateTime.Compare(currentDate, initDate) < 0)
                {
                    break;
                }
                else
                {
                    System.Collections.ArrayList arr = new System.Collections.ArrayList();
                    string str = currentPage.ToString() + " 페이지, 날짜: " + currentDate.ToString();
                    arr.Add(str); arr.Add(currentDate); arr.Add(currentPage - initPage);
                    if (newPageHappened != null)
                        newPageHappened(arr, null);
                    currentPage++;
                }
            }
            //Dictionary value => count, replyNum, gallCount, gallRecommend
            foreach (KeyValuePair<UserInfo, int[]> user in userDic)
            {
                UserInfo tempUser = user.Key;
                tempUser.count = user.Value[0];
                tempUser.replyNum = user.Value[1];
                tempUser.gallCount = user.Value[2];
                tempUser.gallRecommend = user.Value[3];
                UserRank tempUserRank = new UserRank(tempUser, user.Value[0], user.Value[1], user.Value[2], user.Value[3]);
                userList.Add(tempUserRank);
            }
            var sorted = from userRank in userList
                         orderby userRank.count descending
                         select userRank;
            userList = sorted.ToList<UserRank>();
            if(CrawlingEnded != null)
                CrawlingEnded(userList, null);
            string tempDataDir = Directory.GetCurrentDirectory() + "\\temp-data\\";
            Directory.CreateDirectory(tempDataDir);
            string filename = tempDataDir + gallId + DateTime.Now.ToString("_yyyy-MM-dd_HH-mm-ss");
            SaveResult(filename);
        }
        public void SaveResult(string filename)
        {
            string outputUserList = njson.JsonConvert.SerializeObject(userList, njson.Formatting.Indented);
            //string outputUserDatas = njson.JsonConvert.SerializeObject(gallDatas, njson.Formatting.Indented);
            using (var ofile = new StreamWriter(filename + ".json"))
            {
                ofile.WriteLine(outputUserList);
            }
            /*
            using (var ofile = new StreamWriter(filename + ".gall-data.json"))
            {
                ofile.WriteLine(outputUserDatas);
            }
            */
            Console.WriteLine(filename);
            Console.ReadLine();
        }
    }

    public class DataToText
    {
        public string[] telecomIps = //통피
        {
            "203.226", "211.234", "223.32", "223.33", "223.34", "223.35", "223.36", "223.37", "223.38", "223.39", "223.40", "223.41", "223.42", "223.43", "223.44", "223.45", "223.46", "223.47", "223.48", "223.49", "223.50", "223.51", "223.52", "223.53", "223.54", "223.55", "223.56", "223.57", "223.58", "223.59", "223.60", "223.61", "223.62", "223.63",      //SKT
            "39.7", "110.70", "175.223", "175.252", "211.246", "118.235", //KT
            "61.43", "211.234", "117.111", "211.36", "106.102"      //LG U+
        };
        public List<UserRank> userList = new List<UserRank>();
        List<UserData> gallDatas = new List<UserData>();
        public string filename { get; }

        public DataToText(string filename)
        {
            string tempDataDir = Directory.GetCurrentDirectory() + "\\temp-data\\";
            this.filename = filename;
            using (var ifile = new StreamReader(tempDataDir + filename))
            {
                string fileText = ifile.ReadToEnd();
                userList = njson.JsonConvert.DeserializeObject<List<UserRank>>(fileText);
            }
            this.RankingUpdate();
        }
        public void NickChange()
        {
            int user1, user2;
            Console.Write("유저1: ");
            user1 = int.Parse(Console.ReadLine());
            Console.Write("유저 2: ");
            user2 = int.Parse(Console.ReadLine());
            UserMerge(user1, user2);
            foreach (UserRank user in userList)
            {
                Console.WriteLine(user.ToString());
            }
        }
        public void AutoUserManager()
        {
            int index = 0;
            int howManyUser = userList.Count;
            List<int> telecomIpList = new List<int>();
            for (int i = 0; i < howManyUser; i++)
            {
                if (userList[i].userInfos.Count == 1)
                {
                    UserInfo user = userList[i].userInfos[0];
                    if (Array.IndexOf(telecomIps, user.IdorIp) > -1 && user.Nick.Equals("ㅇㅇ"))
                    {
                        telecomIpList.Add(i);
                        index++;
                        Console.WriteLine(index.ToString() + " " + i.ToString());
                    }
                }
            }
            MultiUserMerge(telecomIpList.ToArray<int>());
            int telecomIpFluidNick = telecomIpList.Min();
            userList[telecomIpFluidNick].userInfos = 
                new List<UserInfo> { new UserInfo("ㅇㅇ", "통피", (int)userStatus.fluidNick) };
            for (int i = 0; i < howManyUser; i++)
            {
                for (int k = i + 1; k < howManyUser; k++)
                {
                    if (userList[i].IsSameUser(userList[k]))
                    {
                        UserMerge(i, k);
                    }
                }
            }
            this.RankingUpdate();
        }
        public void UserMerge(int user1, int user2)
        {
            if (user1 < user2)
            {
                userList[user1].userInfos.AddRange(userList[user2].userInfos);
                userList[user1].Update();
                userList[user2].NotUsed();
            }
            else if (user1 == user2) { }
            else
            {
                userList[user2].userInfos.AddRange(userList[user1].userInfos);
                userList[user2].Update();
                userList[user1].NotUsed();
            }
        }
        public void MultiUserMerge(int[] users)
        {
            int original = users.Min();
            foreach (int user in users)
            {
                Console.WriteLine(user);
                UserMerge(original, user);
            }
        }
        public void RankingUpdate()
        {
            var sorted = from userRank in userList
                         orderby userRank.count descending
                         where userRank.status != (int)userStatus.notUsed
                         select userRank;
            userList = sorted.ToList<UserRank>();
        }
        public void SaveToText(string filename, int maximumRank, int minimumCount)
        {
            string resultDir = Directory.GetCurrentDirectory() + "\\results\\";
            Directory.CreateDirectory(resultDir);
            using (StreamWriter sw = new StreamWriter(resultDir + filename))
            {
                this.RankingUpdate();
                int totalCount = 0, totalReply = 0, totalGallCount = 0, totalGallRecommend = 0;
                foreach (UserRank user in userList)
                {
                    totalCount += user.count; totalReply += user.replyNum;
                    totalGallCount += user.gallCount; totalGallRecommend += user.gallRecommend;
                }
                sw.WriteLine("총 글수: " + totalCount.ToString());
                sw.WriteLine("갤창랭킹 2.0 made by hanel2527, 마이 리틀 포니 갤러리");
                sw.WriteLine("랭킹\t닉\t글 수\t갤 지분");
                int index = 0;
                int rank = 0;
                double gallShare;
                for (int i = 0; i < userList.Count; i++)
                {
                    if (userList[i].status == (int)userStatus.notUsed) continue;
                    else
                    {
                        index++;
                        if (index == 1)
                        {
                            rank = 1;
                        }
                        else if (userList[i - 1].count != userList[i].count)
                        {
                            rank = index;
                        }
                        if (rank > maximumRank || userList[i].count < minimumCount)
                        {
                            break;
                        }
                        gallShare = (double)(10000 * userList[i].count / totalCount) / 100.0;
                        string str = rank.ToString() + "위\t" + userList[i].ToString() + "\t" + userList[i].count.ToString() + "글\t" + gallShare.ToString() + "%";
                        sw.WriteLine(str);
                    }
                }
            }
        }
        private string TableMaker(string[] strArr)
        {
            string str = "<tr align='center'>";
            foreach (string temp in strArr)
            {
                str += "<td>" + temp + "</td>";
            }
            return str + "</tr>";
        }
        public void SaveToTable(string filename, int maximumRank, int minimumCount)
        {
            string resultDir = Directory.GetCurrentDirectory() + "\\results\\";
            Directory.CreateDirectory(resultDir);
            using (StreamWriter sw = new StreamWriter(resultDir + filename))
            {
                this.RankingUpdate();
                int totalCount = 0, totalReply = 0, totalGallCount = 0, totalGallRecommend = 0;
                foreach (UserRank user in userList)
                {
                    totalCount += user.count; totalReply += user.replyNum;
                    totalGallCount += user.gallCount; totalGallRecommend += user.gallRecommend;
                }
                sw.Write("<table width='100%' style='border-collapse:collapse' border='1' bordercolor='purple'>");
                sw.Write("<tr align='center'> <td colspan='5'>" + "총 글 수: " + totalCount.ToString() + "</td></tr>");
                sw.Write("<tr align='center'> <td colspan='5'>"+ "갤창랭킹 2.0 made by hanel2527,<br>마이 리틀 포니 갤러리" + "</td></tr>");
                string[] strInfos = { "랭킹", "닉", "아이디/아이피", "글 수", "갤 지분(%)" };
                sw.WriteLine(TableMaker(strInfos));
                int index = 0;
                int rank = 0;
                double gallShare;
                string[] strArr = new string[5];
                for (int i = 0; i < userList.Count; i++)
                {
                    if (userList[i].status == (int)userStatus.notUsed) continue;
                    else
                    {
                        index++;
                        if (index == 1)
                        {
                            rank = 1;
                        }
                        else if (userList[i - 1].count != userList[i].count)
                        {
                            rank = index;
                        }
                        if (rank > maximumRank || userList[i].count < minimumCount)
                        {
                            break;
                        }
                        gallShare = (double)(10000 * userList[i].count / totalCount) / 100.0;
                        strArr[0] = rank.ToString(); strArr[1] = userList[i].ToString("Nick");
                        strArr[2] = userList[i].ToString("IdorIp"); strArr[3] = userList[i].count.ToString();
                        strArr[4] = gallShare.ToString();
                        sw.Write(TableMaker(strArr));
                    }
                }
                sw.WriteLine("</table>");
            }
        }
    }
}

