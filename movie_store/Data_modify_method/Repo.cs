using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using movie_store.Models;


namespace movie_store.Data_modify_method
{
  public class Repo
  {
    
    public static String ApiGetJson(string url)
    {
      HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url); // Create a request to get server info
      try
      {
        WebResponse response = webRequest.GetResponse();

        using (Stream responseStream = response.GetResponseStream())
        {
          StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
          return reader.ReadToEnd();
          }

      }
      catch (WebException ex)
      {
        WebResponse errorResponse = ex.Response;
        using (Stream responseStream = errorResponse.GetResponseStream())
        {
          StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
          string errorText = reader.ReadToEnd();
        }
        throw;
      }
     

    }

  }
}