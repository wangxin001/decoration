using System;
using System.Collections.Generic;
using System.Text;

namespace WX
{
   public class HandlerFactory
    {
       public static IHandler create(string requestXml)
        {
           
            switch ( MsgType.LoadFromXml(requestXml).ToLower())
            {
                case "text":
                    return new MessageHandler(requestXml);            
                case"image":
                    break;
                case "location":
                    return new LocationHandler(requestXml);
                case "link":
                    break;
                case "event":
                    return new EventHandler(requestXml);      
                default:
                    break;
 
                    
            }
            return null;
        }
    }
}
