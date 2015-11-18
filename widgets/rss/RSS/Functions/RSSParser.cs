using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;

namespace RSS.Functions
{
    class RSSParser
    {
        #region 속성
        private string _Title;
        public string Title
        {
            get { return _Title; }
        }

        private string _Link;
        public string Link
        {
            get { return _Link; }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
        }

        private Languages _Language;
        public Languages Language
        {
            get { return _Language; }
        }

        private DateTime _PublicationDate;
        public DateTime PublicationDate
        {
            get { return _PublicationDate; }
        }

        private string _Generator;
        public string Generator
        {
            get { return _Generator; }
        }

        private string _ManagingEditor;
        public string ManagingEditor
        {
            get { return _ManagingEditor; }
        }

        private List<Item> _Items;
        public List<Item> Items
        {
            get { return _Items; }
        }
        #endregion

        #region 열거형
        public enum Codes
        {
            AF,
            SQ,
            EU,
            BE,
            BG,
            CA,
            ZH_CN,
            ZH_TW,
            HR,
            CS,
            DA,
            NL,
            NL_BE,
            NL_NL,
            EN,
            EN_AU,
            EN_BZ,
            EN_CA,
            EN_IE,
            EN_JM,
            EN_NZ,
            EN_PH,
            EN_ZA,
            EN_TT,
            EN_GB,
            EN_US,
            EN_ZW,
            ET,
            FO,
            FI,
            FR,
            FR_BE,
            FR_CA,
            FR_FR,
            FR_LU,
            FR_MC,
            FR_CH,
            GL,
            GD,
            DE,
            DE_AT,
            DE_DE,
            DE_LI,
            DE_LU,
            DE_CH,
            EL,
            HAW,
            HU,
            IS,
            IN,
            GA,
            IT,
            IT_IT,
            IT_CH,
            JA,
            KO,
            MK,
            NO,
            PL,
            PT,
            PT_BR,
            PT_PT,
            RO,
            RO_MO,
            RO_RO,
            RU,
            RU_MO,
            RU_RU,
            SR,
            SK,
            SL,
            ES,
            ES_AR,
            ES_BO,
            ES_CL,
            ES_CO,
            ES_CR,
            ES_DO,
            ES_EC,
            ES_SV,
            ES_GT,
            ES_HN,
            ES_MX,
            ES_NI,
            ES_PA,
            ES_PY,
            ES_PE,
            ES_PR,
            ES_ES,
            ES_UY,
            ES_VE,
            SV,
            SV_FI,
            SV_SE,
            TR,
            UK,
            UNKNOWN
        }

        public enum Languages
        {
            Afrikaans,
            Albanian,
            Basque,
            Belarusian,
            Bulgarian,
            Catalan,
            Chinese_Simplified,
            Chinese_Traditional,
            Croatian,
            Czech,
            Danish,
            Dutch,
            Dutch_Belgium,
            Dutch_Netherlands,
            English,
            English_Australia,
            English_Belize,
            English_Canada,
            English_Ireland,
            English_Jamaica,
            English_NewZealand,
            English_Phillipines,
            English_SouthAfrica,
            English_Trinidad,
            English_UnitedKingdom,
            English_UnitedStates,
            English_Zimbabwe,
            Estonian,
            Faeroese,
            Finnish,
            French,
            French_Belgium,
            French_Canada,
            French_France,
            French_Luxembourg,
            French_Monaco,
            French_Switzerland,
            Galician,
            Gaelic,
            German,
            German_Austria,
            German_Germany,
            German_Liechtenstein,
            German_Luxembourg,
            German_Switzerland,
            Greek,
            Hawaiian,
            Hungarian,
            Icelandic,
            Indonesian,
            Irish,
            Italian,
            Italian_Italy,
            Italian_Switzerland,
            Japanese,
            Korean,
            Macedonian,
            Norwegian,
            Polish,
            Portuguese,
            Portuguese_Brazil,
            Portuguese_Portugal,
            Romanian,
            Romanian_Moldova,
            Romanian_Romania,
            Russian,
            Russian_Moldova,
            Russian_Russia,
            Serbian,
            Slovak,
            Slovenian,
            Spanish,
            Spanish_Argentina,
            Spanish_Bolivia,
            Spanish_Chile,
            Spanish_Colombia,
            Spanish_Costa,
            Spanish_DominicanRepublic,
            Spanish_Ecuador,
            Spanish_ElSalvador,
            Spanish_Guatemala,
            Spanish_Honduras,
            Spanish_Mexico,
            Spanish_Nicaragua,
            Spanish_Panama,
            Spanish_Paraguay,
            Spanish_Peru,
            Spanish_PuertoRico,
            Spanish_Spain,
            Spanish_Uruguay,
            Spanish_Venezuela,
            Swedish,
            Swedish_Finland,
            Swedish_Sweden,
            Turkish,
            Ukranian,
            Unknown
        }
        #endregion

        #region 생성자
        public RSSParser(string URL)
        {
            // 도큐멘트 읽기
            XmlDocument document = new XmlDocument();
            document.Load(URL);

            // 도큐멘트 정보 분석
            _Title = document.GetElementsByTagName("title")[0]?.InnerText.Trim();
            _Link = document.GetElementsByTagName("link")[0]?.InnerText.Trim();
            _Description = document.GetElementsByTagName("description")[0]?.InnerText.Trim();
            _Language = CodeToLanguage(ParseCode(document.GetElementsByTagName("language")[0]?.InnerText.Trim()));
            DateTime.TryParse(document.GetElementsByTagName("pubDate")[0]?.InnerText.Trim(), out _PublicationDate);
            _Generator = document.GetElementsByTagName("generator")[0]?.InnerText.Trim();
            _ManagingEditor = document.GetElementsByTagName("managingEditor")[0]?.InnerText.Trim();

            // 도큐멘트 내용 분석
            List<Item> result = new List<Item>();
            foreach(XmlElement node in document.GetElementsByTagName("item"))
            {
                DateTime publicationDate;
                DateTime.TryParse(node.GetElementsByTagName("pubDate")[0]?.InnerText.Trim(), out publicationDate);

                Item item = new Item(
                    node.GetElementsByTagName("title")[0]?.InnerText.Trim(),
                    node.GetElementsByTagName("link")[0]?.InnerText.Trim(),
                    node.GetElementsByTagName("description")[0]?.InnerText.Trim(),
                    node.GetElementsByTagName("category")[0]?.InnerText.Trim(),
                    node.GetElementsByTagName("author")[0]?.InnerText.Trim(),
                    node.GetElementsByTagName("guid")[0]?.InnerText.Trim(),
                    node.GetElementsByTagName("comments")[0]?.InnerText.Trim(),
                    publicationDate
                );

                result.Add(item);
            }
            _Items = result;
        }
        #endregion

        #region 사용자 함수
        public Languages CodeToLanguage(Codes code)
        {
            return (Languages)Convert.ToInt32(code);
        }

        public Codes LanguageToCode(Languages language)
        {
            return (Codes)Convert.ToInt32(language);
        }

        public Codes ParseCode(string value)
        {
            if (value == null || value?.Length <= 0)
            {
                return Codes.UNKNOWN;
            }
            else
            {
                return (Codes)Enum.Parse(typeof(Codes), value.ToUpper());
            }
        }

        public string GetPlainText(string value)
        {
            try
            {
                string result;
                result = Regex.Replace(value, @"( )+", " ");
                result = Regex.Replace(result, @"<( )*head([^>])*>", "<head>", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, @"(<( )*(/)( )*head( )*>)", "</head>", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, "(<head>).*(</head>)", string.Empty, RegexOptions.IgnoreCase);
                result = Regex.Replace(result, @"<( )*script([^>])*>", "<script>", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, @"(<( )*(/)( )*script( )*>)", "</script>", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, @"(<script>).*(</script>)", string.Empty, RegexOptions.IgnoreCase);
                result = Regex.Replace(result, @"<( )*style([^>])*>", "<style>", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, @"(<( )*(/)( )*style( )*>)", "</style>", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, "(<style>).*(</style>)", string.Empty, RegexOptions.IgnoreCase);
                result = Regex.Replace(result, @"<( )*td([^>])*>", "\t", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, @"<( )*br( )*>", "\r", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, @"<( )*li( )*>", "\r", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, @"<( )*div([^>])*>", "\r\r", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, @"<( )*tr([^>])*>", "\r\r", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, @"<( )*p([^>])*>", "\r\r", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, @"<[^>]*>", string.Empty, RegexOptions.IgnoreCase);
                result = Regex.Replace(result, @" ", " ", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, @"&bull;", " * ", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, @"&lsaquo;", "<", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, @"&rsaquo;", ">", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, @"&trade;", "(tm)", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, @"&frasl;", "/", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, @"&lt;", "<", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, @"&gt;", ">", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, @"&copy;", "(c)", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, @"&reg;", "(r)", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, @"&(.{2,6});", string.Empty, RegexOptions.IgnoreCase);
                result = Regex.Replace(result, "(\r)( )+(\r)", "\r\r", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, "(\t)( )+(\t)", "\t\t", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, "(\t)( )+(\r)", "\t\r", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, "(\r)( )+(\t)", "\r\t", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, "(\r)(\t)+(\r)", "\r\r", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, "(\r)(\t)+", "\r\t", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, @"[^a-zA-Z0-9가-힣\s]", "");
                result = Regex.Replace(result, @"\r\n?|\n", " ");
                result = Regex.Replace(result, @"\s+", " ");
                return result.Trim();
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }

    public class Item
    {
        #region 속성
        private string _Title;
        public string Title
        {
            get { return _Title; }
        }

        private string _Link;
        public string Link
        {
            get { return _Link; }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
        }

        private string _Category;
        public string Category
        {
            get { return _Category; }
        }

        private string _Author;
        public string Author
        {
            get { return _Author; }
        }

        private string _GUID;
        public string GUID
        {
            get { return _GUID; }
        }

        private string _Comments;
        public string Comments
        {
            get { return _Comments; }
        }

        private DateTime _PublicationDate;
        public DateTime PublicationDate
        {
            get { return _PublicationDate; }
        }
        #endregion

        #region 생성자
        public Item(string title, string link, string description, string category, string author, string guid, string comments, DateTime publicationDate)
        {
            _Title = title;
            _Link = link;
            _Description = description;
            _Category = category;
            _Author = author;
            _GUID = guid;
            _Comments = comments;
            _PublicationDate = publicationDate;
        }
        #endregion
    }
}
