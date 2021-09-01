using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace XmlParsingTestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string test="asd";
            string emptyString = string.Empty;
            string nowDateString = DateTime.Now.ToString("yyyy-MM-dd");
            string nowDateUtcString = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz");

            List<DOCLEVELSLEVEL> levels = new List<DOCLEVELSLEVEL>
            {
                new DOCLEVELSLEVEL
                {
                    Type = "TRADE",
                    Name = "CARTON",
                    Count = "2131",
                    UnitCapacity = "1"
                },
                new DOCLEVELSLEVEL
                {
                    Type = "LOGISTICS",
                    Name = "CASE",
                    Count = "22",
                    UnitCapacity = "100"
                },
                new DOCLEVELSLEVEL
                {
                    Type = "LOGISTICS",
                    Name = "PALLET",
                    Count = "2",
                    UnitCapacity = "16"
                },
            };
            List<DOCSERIALSECTIONSERIAL> serialSections = new List<DOCSERIALSECTIONSERIAL>
            {
                new DOCSERIALSECTIONSERIAL
                {
                   AI91 = "EE07",
                   AI92 = "pdkkhijc05pyCUxoY+4G59fp8xEinkPzxL9mK4dSoGQ=",
                   STATE = "Ok",
                   Value = "10000000000eQ"
                },
                new DOCSERIALSECTIONSERIAL
                {
                   AI91 = "EE07",
                   AI92 = "2MYtIxbJ06wWGfXEA5TAUkae8cmU+Z+otaMGhrE2+rg=",
                   STATE = "Ok",
                   Value = "10000000000eR"
                },
            };
            List<DOCAGGREGATIONSERIALXX> aggregations = new List<DOCAGGREGATIONSERIALXX>
            {
                new DOCAGGREGATIONSERIALXX
                {
                    Type = "SSCC",
                    ItemType = "SERIAL",
                    Level = "CASE",
                    Code = "103800021110223523",
                    ItemCount ="100",
                    Timestamp = nowDateUtcString,
                    Line = "Test1",
                    ITEM = new List<DOCAGGREGATIONSERIALXXITEM>
                    {
                        new DOCAGGREGATIONSERIALXXITEM
                        {
                            Value = "10000000000wg"
                        },
                        new DOCAGGREGATIONSERIALXXITEM
                        {
                            Value = "10000000000wh"
                        }
                    }
                },
                new DOCAGGREGATIONSERIALXX
                {
                    Type = "SSCC",
                    ItemType = "SERIAL",
                    Level = "CASE",
                    Code = "103800021110223523",
                    ItemCount ="100",
                    Timestamp = nowDateUtcString,
                    Line = "Test2",
                    ITEM = new List<DOCAGGREGATIONSERIALXXITEM>
                    {
                        new DOCAGGREGATIONSERIALXXITEM
                        {
                            Value = "10000000000wg"
                        },
                        new DOCAGGREGATIONSERIALXXITEM
                        {
                            Value = "10000000000wh"
                        }
                    }
                }
            };
            DOC docItem = new DOC
            {
                version = "2.0",
                CIP = "03800021110392",
                LOT = "0040321",
                EXP = nowDateString,
                MNF = nowDateString,
                PRICE = emptyString,
                DATEFORMAT = "MM\"/\"YYYY",
                STYPE = "AUTO",
                SERIALCOUNT = "2131",
                SPREFIX = emptyString,
                SSUFFIX = emptyString,
                SLEN = emptyString,
                SALPHABET = emptyString,
                SSEQSTART = emptyString,
                SSEQSTEP = emptyString,
                //LEVELS = levels,
                //SERIALSECTION = serialSections,
                //AGGREGATION = aggregations
            };
            docItem.LEVELS = levels;
            docItem.SERIALSECTION = serialSections;
            docItem.AGGREGATION = aggregations;

            XmlSerializer mySerializer = new XmlSerializer(typeof(DOC));
            StreamWriter myWriter = new StreamWriter("C:\\Users\\OnderTurhan\\Downloads\\SGSATT_03800021110392_0040321BID621_202104071336_generated.xml");
            mySerializer.Serialize(myWriter, docItem);
            myWriter.Close();

        }
    }
}
