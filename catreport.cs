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

  var ConnectionString = DotNetNuke.Common.Utilities.Config.GetConnectionString();

  SqlConnection database = new SqlConnection(ConnectionString);

  cmd.CommandText = "Select Cat_Color, COUNT(*) as 'num' From CatResponses Group by Cat_Color";

  cmd.CommandType = CommandType.Text;

  cmd.Connection = database;

  database.Open();

  reader = cmd.ExecuteReader();

  List<string> color = new List<string>();
  List<int> num = new List<int>();


  try
  {
    while(reader.Read())
    {

      color.Add(Convert.ToString(reader[0]));
      num.Add(Convert.ToInt32(reader[1]));

    }

    int [] yValues = num.ToArray<int>();
    string [] xValues = color.ToArray<string>();

    var myChart = new Chart(width: 600, height: 400);
    myChart.AddTitle("Felineality Color");
    myChart.AddSeries(name: "Color", chartType: "column", xValue: xValues, xField: "Color", yValues: yValues, yFields: "count");
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
