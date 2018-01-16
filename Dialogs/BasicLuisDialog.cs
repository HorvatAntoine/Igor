using System;
using System.Configuration;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace Microsoft.Bot.Sample.LuisBot
{
    // For more information about this template visit http://aka.ms/azurebots-csharp-luis
    [Serializable]
    public class BasicLuisDialog : LuisDialog<object>
    {
        public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(
            ConfigurationManager.AppSettings["LuisAppId"], 
            ConfigurationManager.AppSettings["LuisAPIKey"], 
            domain: ConfigurationManager.AppSettings["LuisAPIHostName"])))
        {
        }

        [LuisIntent("None")]
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Je suis désolé. Je n'ai pas compris.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Salutations")]
        public async Task Greetings(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Bonjour à vous ! Que puis-je faire pour vous ?");
            context.Wait(MessageReceived);
        }

        [LuisIntent("AboutIgor")]
        public async Task AboutMe(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(@"Ankit is a Software Engineer currently working in Microsoft Center of Excellence team at Mindtree. He started his professional career in 2013 after completing his graduation as Bachelor in Computer Science.");
            await context.PostAsync(@"He is a technology enthusiast and loves to dig in emerging technologies. Most of his working hours are spent on creating architecture, evaluating upcoming products and developing frameworks.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("DemandeInfo")]
        public async Task DemandeInfo(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Il vous reste 8 jours de congés restant sur l'année en cours");
            context.Wait(MessageReceived);
        }

       // private async Task ShowLuisResult(IDialogContext context, LuisResult result) 
       //{
       //     await context.PostAsync($"You have reached {result.Intents[0].Intent}. You said: {result.Query}");
       //     context.Wait(MessageReceived);
       // }
    }
}