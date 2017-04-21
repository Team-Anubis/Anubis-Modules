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

@*Copyright (c) 2017 by Anubis *@

<body>
<h2>Readiness Value Report</h2>
<h6>Current determing value for readiness: 13</h6>
<table class="table table-hover">
<thead>
  <tr>
    <th>Readiness Value</th>
    <th>Number of people who have recieved the value</th>
  </tr>
</thead>
<tbody>
@{
  var ConnectionString = DotNetNuke.Common.Utilities.Config.GetConnectionString();
  var database = new SqlConnection(ConnectionString);

  var selectQueryString = "Select Readiness, COUNT(*) as 'num' From Responses Group by Readiness";

  SqlCommand command = new SqlCommand(selectQueryString, database);
  database.Open();
  SqlDataReader reader = command.ExecuteReader();

  try
  {
    while(reader.Read())
    {
    <tr>
      <td>@reader[0]</td>
      <td>@reader[1]</td>
    </tr>
    }
  }

  catch
  {

  }

  finally
  {
    reader.Close();
  }
}

</tbody>
</table>
<p><img src="Readiness-Report" /></p>
<h2>Feline-ality Color Report</h2>
<table class="table table-hover">
<thead>
<tr>
<th>Color(s)</th>
<th>Number of people who have recieved the color(s)</th>
</tr>
</thead>
<tbody>
@{

  var selectQueryString2 = "Select Cat_Color, COUNT(*) as 'num' From CatResponses Group by Cat_Color";

  SqlCommand command2 = new SqlCommand(selectQueryString2, database);
  SqlDataReader reader2 = command2.ExecuteReader();

  try
  {
    while(reader2.Read())
    {
    <tr>
      <td>@reader2[0]</td>
      <td>@reader2[1]</td>
    </tr>
    }
  }

  catch
  {

  }

  finally
  {
  reader2.Close();
  }

}
</tbody>
</table>
<p><img src="Felinealiity-Report" /><br></p>
<h2>Caine-ality Color Report</h2>
<table class="table table-hover">
<thead>
<tr>
<th>Color(s)</th>
<th>Number of people who have recieved the color(s)</th>
</tr>
</thead>
<tbody>

@{

  var selectQueryString3 = "Select Dog_Color, COUNT(*) as 'num' From DogResponses Group by Dog_Color";

  SqlCommand command3 = new SqlCommand(selectQueryString3, database);
  SqlDataReader reader3 = command3.ExecuteReader();

  try
  {
    while(reader3.Read())
    {
    <tr>
      <td>@reader3[0]</td>
      <td>@reader3[1]</td>
    </tr>
    }

  }

  catch
  {

  }

  finally
  {
    reader3.Close();
    database.Close();
  }

}
</tbody>
</table>
<p><img src="Canineality-Report" /></p>

</body>
