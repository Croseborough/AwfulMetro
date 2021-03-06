﻿using System.Linq;
using System.Threading.Tasks;
using AwfulMetro.Core.Entity;
using AwfulMetro.Core.Tools;

namespace AwfulMetro.Core.Manager
{
    public class ForumUserManager
    {
        private readonly IWebManager _webManager;
        public ForumUserManager(IWebManager webManager)
        {
            this._webManager = webManager;
        }

        public ForumUserManager() : this(new WebManager()) { }

        public async Task<ForumUserEntity> GetUserFromProfilePage(ForumUserEntity user, long userId)
        {
            string url = Constants.BASE_URL + string.Format(Constants.USER_PROFILE, userId);
            var doc = (await _webManager.DownloadHtml(url)).Document;
            
            return string.IsNullOrEmpty(user.Username) ? ForumUserEntity.FromPost(doc.DocumentNode.Descendants("td").FirstOrDefault(node => node.GetAttributeValue("id", string.Empty).Contains("thread"))) : ForumUserEntity.FromUserProfile(doc.DocumentNode.Descendants("td").FirstOrDefault(node => node.GetAttributeValue("class", string.Empty).Contains("info")));
        }
    }
}
