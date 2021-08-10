using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GarbageCollection {
  class CSVManager {
    private ArrayList _tweets;
    private StreamReader _csvStreamer;
    internal CSVManager() {
      _tweets = new ArrayList();
    }

    internal ArrayList ReadUsingFileReadLines(string filePath) {
      IEnumerable<string> rows = File.ReadLines(filePath);
      foreach (string row in rows.Skip(1)) {
        string[] queryArray = ParseStringToArray(row);
        try {
          Tweet tweet = new Tweet(queryArray);
          _tweets.Add(tweet);
        }
        catch (Exception createTweetObjectFailed) {
          Console.WriteLine($"{queryArray[0]} Message: { createTweetObjectFailed.Message } ");
        }

      }
      return _tweets;
    }

    // outputnya List of string System.IO, File.ReadAllText

    private string[] ParseStringToArray(string text) {
      text.Replace(",,", ", ,");
      string[] queryArray = text.Split(',');
      return queryArray;
    }

    private string[] DynamicObjectToArray(dynamic obj) {
      string[] queryArray = new string[] {
        obj.ID, obj.lang, obj.Date, obj.Source, obj.len, obj.Tweet, obj.Likes, 
        obj.RTs, obj.Hashtags, obj.UserMentionNames, obj.UserMentionID, 
        obj.Name, obj.Place, obj.Followers, obj.Friends
      };
      return queryArray;
    }
  }
}
