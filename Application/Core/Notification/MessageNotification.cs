using Application.Core.HelperClass;
using Application.Core.Responses;
using Application.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Application.Core.Notification
{

    public interface IMessageNotification
    {
        Response SendEmail(string email, string subject, string messageBody);
        //Response SendEmailAsync(string receiver, string subject, string htmlMessage);
        //Response SendEmailAsync(string sender, string receiver, string subject, string htmlMessage);
        Response SendSMS(string phoneNumber, string messageBody);

    }

    public class MessageNotification : IMessageNotification
    {
        private readonly IOptions<EmailSettings> _emailSettings;
        private readonly IOptions<SMSSettings> _smsSettings;
        private readonly IOptions<SendGridSetting>  _sendgridSettings;
        private readonly ITwilioRestClient _client;

		public MessageNotification(IOptions<EmailSettings> emailSettings, IOptions<SMSSettings> smsSettings = null, ITwilioRestClient client = null, IOptions<SendGridSetting> sendgridSettings = null)
		{
			this._emailSettings = emailSettings;
			this._smsSettings = smsSettings;
			this._client = client;
			this._sendgridSettings = sendgridSettings;
		}

		public Response SendEmail(string email, string subject, string messageBody)
        {

            MailMessage msg = new MailMessage
            {
                From = new MailAddress(_emailSettings.Value.OriginEmail),
            };
            msg.To.Add(email);

            msg.Subject = subject;
            msg.Body = messageBody;


            SmtpClient client = new SmtpClient
            {
                Host = _emailSettings.Value.Host
            };
            NetworkCredential credential = new NetworkCredential
            {  // Server Email credential
                UserName = _emailSettings.Value.UserName,
                Password = _emailSettings.Value.Password
            };
            client.Credentials = credential;
            client.EnableSsl = _emailSettings.Value.EnableSsl;
            client.Port = _emailSettings.Value.Port;
            try
            {
                client.Send(msg);
                return CoreResponse.GlobalResponse(msg, "Email was sent successfuly", ResponseStatus.Success, ResponseCode.SuccesFullOperation);
            }


            catch (Exception exp)
            {
                return CoreResponse.OnFailureResponse(msg, exp.Message);
            }


        }

        public Response SendSMS(string phoneNumber, string messageBody)
        {
			try
			{
                var str = phoneNumber.Remove(0, 1);
                var number = $"+234{str}";
                var message = MessageResource.Create(
                    to: new Twilio.Types.PhoneNumber(number),
                    from: new Twilio.Types.PhoneNumber(_smsSettings.Value.FromNumber),
                    body: messageBody,
                    client: _client
                    );
                return CoreResponse.OnSuccess(message.Sid);
            }
            catch(Exception exp)
			{
                return CoreResponse.OnFailureResponse(messageBody, exp.Message);
			}
           

        }

        //public async Response SendEmailAsync(string receiver, string subject, string htmlMessage)
        //{
        //     var status = await this.SendEmailAsync(Universe.AdminEmail, receiver, subject, htmlMessage);
        //}
          

        //public async Task<bool> SendEmailAsync(string sender, string receiver, string subject, string htmlMessage)
        //{
        //    var client = new SendGridClient(this._sendgridSettings.Value.ApiKey);
        //    var from = new EmailAddress(sender);
        //    var to = new EmailAddress(receiver, receiver);
        //    var msg = MailHelper.CreateSingleEmail(from, to, subject, htmlMessage, htmlMessage);

        //    try
        //    {
        //        var isSuccessful = await client.SendEmailAsync(msg);

        //        return isSuccessful.StatusCode == HttpStatusCode.Accepted;
        //    }
        //    catch
        //    {
        //        // Ignored
        //        return false;
        //    }
        //}

    }

}
