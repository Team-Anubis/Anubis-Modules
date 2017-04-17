@using DotNetNuke.Common;
@using System;
@using DotNetNuke.Entities.Modules;
@using System.Data.SqlClient;
@using System.Diagnostics;
@using System.Data;
@using System.Data.Common;
@using System.Collections.Generic;
@using System.Linq;
@using System.Text;
@using System.Net.Mail;
@using System.Net;
@using System.Windows.Forms;
@using System.Web.UI;

@*Copyright (c) 2017 by Anubis *@

<body>


@{

  SqlCommand cmd = new SqlCommand();

  SqlDataReader reader;

  SqlConnection database = new SqlConnection("Data Source=gpsql.nau.froot.nau.edu,61707;Initial Catalog=petready;Integrated Security=True;");

  cmd.CommandText = "Select Readiness, COUNT(*) as 'num' From Responses Group by Readiness";

  cmd.CommandType = CommandType.Text;

  cmd.Connection = database;

  database.Open();

  reader = cmd.ExecuteReader();

  List<int> readiness = new List<int>();
  List<int> num = new List<int>();


  try
  {
    while(reader.Read())
    {

      readiness.Add(Convert.ToInt32(reader[0]));
      num.Add(Convert.ToInt32(reader[1]));

    }

    int [] yValues = num.ToArray<int>();
    int [] xValues = readiness.ToArray<int>();

    var myChart = new Chart(width: 600, height: 400);
    myChart.AddTitle("Readiness Level");
    myChart.AddSeries(name: "readiness value", chartType: "column", xValue: xValues, xField: "Readiness Value", yValues: yValues, yFields: "count");
    myChart.AddLegend();
    myChart.Write();


  }

  catch
  {

  }
  finally
  {
    database.Close();
    reader.Close();

  }

}

</body>
