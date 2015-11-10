using CoreTweet;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static CoreTweet.OAuth;
namespace Wox.Plugin.Twitter
{
    public partial class PINInputForm : Form
    {
        private string _postMassage;
        private OAuthSession _session;
        private object DynamicJson;

        public PINInputForm(string postMassage, OAuthSession session)
        {
            _postMassage = postMassage;
            _session = session;
            InitializeComponent();
        }

        private void PINInputForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(pinInputText.Text != null)
            {
                string pinCode = pinInputText.Text;
                Tokens tokens = _session.GetTokens(pinCode);
                tokens.Statuses.Update(status => _postMassage);
                //あとはTokenの保存処理                
            }
        }
        
        private void outputAccessTokens(Tokens tokens)
        {
            IDictionary<string, string> tokenMap = new Dictionary<string, string>();
            tokenMap.Add("AccessToken", tokens.AccessToken);
            tokenMap.Add("AccessTokenSecret", tokens.AccessTokenSecret);
        }
    }
}
