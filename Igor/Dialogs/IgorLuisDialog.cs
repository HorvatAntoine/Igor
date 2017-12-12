using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Threading.Tasks;

namespace Igor.Dialogs
{
    [LuisModel("c91e0320-9059-442d-ac0a-ee1672ae04ad", "6f647987006a40fe8bf08fdca895bfe2")]
    [Serializable()]
    internal class IgorLuisDialog : LuisDialog<object>
    {

        public IgorLuisDialog(params ILuisService[] services) : base(services)
        {
        }

        [LuisIntent("None")]
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("I'm sorry. I didn't understand you.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Greetings")]
        public async Task Greetings(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Bonjour à vous ! Que puis-je faire pour vous ?");
            context.Wait(MessageReceived);
        }

        [LuisIntent("AboutMe")]
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
    }
}