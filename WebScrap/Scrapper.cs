﻿using CarTradeCenter.Data.Models;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;


namespace CarTradeCenter.WebScrap
{
    public class Scrapper
    {
        private readonly HttpClient HttpClient;
        private readonly HtmlDocument HtmlDocument;

        public Scrapper()
        {
            this.HttpClient = new HttpClient();
            this.HtmlDocument = new HtmlDocument();
        }


        public string GetPageTextRaw(string url)
        {
            var html = HttpClient.GetStringAsync(url).GetAwaiter().GetResult();
            HtmlDocument.LoadHtml(html);
            return HtmlDocument.Text.ToString();
        }


        public string NodeCutter(string node, string start, string end)
        {
            int cutStartPosition = node.IndexOf(start) + start.Length;
            string nodePart = node.Substring(cutStartPosition, node.Length - 1 - cutStartPosition);
            int cutEndPosition = nodePart.IndexOf(end);
            return nodePart.Substring(0, cutEndPosition);
        }


        public string NodeCutter(string node, string start)
        {
            int cutStartPosition = node.IndexOf(start) + start.Length;
            return node.Substring(cutStartPosition, node.Length - 1 - cutStartPosition);
        }
    }
}
