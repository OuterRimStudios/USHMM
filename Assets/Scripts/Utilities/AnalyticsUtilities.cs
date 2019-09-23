using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CsvHelper;

namespace OuterRimStudios.Utilities
{

    public static class AnalyticsUtilities
    {
        public static void Event<T>(string eventName, List<T> data)
        {
            bool createHeaders = false;
            string date = DateTime.Today.ToString("d").Replace('/', '-');
            if (!Directory.Exists(Application.dataPath + "\\Analytics\\"))
                Directory.CreateDirectory(Application.dataPath + "\\Analytics\\");
            if (!File.Exists(Application.dataPath + "\\Analytics\\" + eventName + "Analytics_" + date + ".csv"))
                createHeaders = true;

            using (var writer = new StreamWriter(Application.dataPath + "\\Analytics\\" + eventName + "Analytics_" + date + ".csv", append: true))
            using (var csv = new CsvWriter(writer))
            {
                csv.Configuration.HasHeaderRecord = createHeaders;
                csv.WriteRecords(data);
            }
        }
    }
}