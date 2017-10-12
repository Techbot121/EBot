﻿using DSharpPlus.Entities;
using EBot.Logs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBot.Commands.Modules
{
    class SocialCommands
    {
        private string Name = "Social";
        private CommandsHandler Handler;
        private BotLog Log;

        public void Setup(CommandsHandler handler, BotLog log)
        {
            this.Handler = handler;
            this.Log = log;
        }

        private void Hug(CommandReplyEmbed embedrep, DiscordMessage msg, List<string> args)
        {
            Social.Action action = new Social.Action();
            string result = "";
            if (!string.IsNullOrWhiteSpace(args[0]) && !string.IsNullOrWhiteSpace(msg.MentionedUsers[0].Username))
            {
                result = action.Hug(msg.Author, msg.MentionedUsers);
                embedrep.Good(msg, "Hug!", result);
            }
            else
            {
                embedrep.Danger(msg, "Aw", "You need to mention the persons you want to hug!");
            }

        }

        private void Boop(CommandReplyEmbed embedrep, DiscordMessage msg, List<string> args)
        {
            Social.Action action = new Social.Action();
            string result = "";
            if (!string.IsNullOrWhiteSpace(args[0]) && !string.IsNullOrWhiteSpace(msg.MentionedUsers[0].Username))
            {
                result = action.Boop(msg.Author, msg.MentionedUsers);
                embedrep.Good(msg, "Boop!", result);
            }
            else
            {
                embedrep.Danger(msg, "Aw", "You need to mention the persons you want to boop!");
            }

        }

        private void Slap(CommandReplyEmbed embedrep, DiscordMessage msg, List<string> args)
        {
            Social.Action action = new Social.Action();
            string result = "";
            if (!string.IsNullOrWhiteSpace(args[0]) && !string.IsNullOrWhiteSpace(msg.MentionedUsers[0].Username))
            {
                result = action.Slap(msg.Author, msg.MentionedUsers);
                embedrep.Good(msg, "Slap!", result);
            }
            else
            {
                embedrep.Danger(msg, "Aw", "You need to mention the persons you want to slap!");
            }

        }

        public void Load()
        {
            this.Handler.LoadCommand(new string[]{ "hug","hugs"}, this.Hug, "hug the users you mentionned");
            this.Handler.LoadCommand("boop", this.Boop, "boop the users you mentionned");
            this.Handler.LoadCommand("slap", this.Slap, "slap the users you mentionned");

            this.Log.Nice("Module", ConsoleColor.Green, "Loaded " + this.Name);
        }

        public void Unload()
        {
            this.Handler.UnloadCommand("hug");
            this.Handler.UnloadCommand("boop");
            this.Handler.UnloadCommand("slap");

            this.Log.Nice("Module", ConsoleColor.Green, "Unloaded " + this.Name);
        }
    }
}