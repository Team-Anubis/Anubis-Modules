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
<h3>Current Registered Users: </h3>
@{
  var ConnectionString = DotNetNuke.Common.Utilities.Config.GetConnectionString();
  var database = new SqlConnection(ConnectionString);
  var countQueryString = "Select COUNT(*) as 'Total User Count' From Users";

  SqlCommand Countcommand = new SqlCommand(countQueryString, database);
  database.Open();
  SqlDataReader Countreader = Countcommand.ExecuteReader();

  try
  {
    while(Countreader.Read())
    {
      <h5>@Countreader[0]</h5>
    }
  }

  catch
  {

  }

  finally
  {
    Countreader.Close();
  }
}
<hr></hr>
<h3>Readiness questionnaire Distinct users: </h3>
@{
  var count1QueryString = "SELECT COUNT(DISTINCT User_ID) 'Users that have completed the Readiness Questionnaire' FROM Responses;";
  SqlCommand Count1command = new SqlCommand(count1QueryString, database);
  SqlDataReader Count1reader = Count1command.ExecuteReader();

  try
  {
    while(Count1reader.Read())
    {
      <h5>@Count1reader[0]</h5>
    }
  }

  catch
  {

  }

  finally
  {
    Count1reader.Close();
  }
}
<hr></hr>
<h3>Feline-ality Distinct users: </h3>
@{
  var count2QueryString = "SELECT COUNT(DISTINCT User_ID) 'Users that have completed the Readiness Questionnaire' FROM CatResponses;";
  SqlCommand Count2command = new SqlCommand(count2QueryString, database);
  SqlDataReader Count2reader = Count2command.ExecuteReader();

  try
  {
    while(Count2reader.Read())
    {
      <h5>@Count2reader[0]</h5>
    }
  }

  catch
  {

  }

  finally
  {
    Count2reader.Close();
  }
}
<hr></hr>
<h3>Canine-ality Distinct users: </h3>
@{
  var count3QueryString = "SELECT COUNT(DISTINCT User_ID) 'Users that have completed the Readiness Questionnaire' FROM DogResponses;";
  SqlCommand Count3command = new SqlCommand(count3QueryString, database);
  SqlDataReader Count3reader = Count3command.ExecuteReader();

  try
  {
    while(Count3reader.Read())
    {
      <h5>@Count3reader[0]</h5>
    }
  }

  catch
  {

  }

  finally
  {
    Count3reader.Close();
  }
}
<hr></hr>
<h3>Number of users above the readiness value: </h3>
@{
  var count4QueryString = "Select COUNT(Distinct User_ID) as 'count' From Responses Where Readiness >= 13";
  SqlCommand Count4command = new SqlCommand(count4QueryString, database);
  SqlDataReader Count4reader = Count4command.ExecuteReader();

  try
  {
    while(Count4reader.Read())
    {
      <h5>@Count4reader[0]</h5>
    }
  }

  catch
  {

  }

  finally
  {
    Count4reader.Close();
  }
}
<hr></hr>
<h3>Number of users below the readiness value: </h3>
@{
  var count5QueryString = "Select COUNT(DISTINCT User_ID) as 'count' From Responses Where Readiness < 13";
  SqlCommand Count5command = new SqlCommand(count5QueryString, database);
  SqlDataReader Count5reader = Count5command.ExecuteReader();

  try
  {
    while(Count5reader.Read())
    {
      <h5>@Count5reader[0]</h5>
    }
  }

  catch
  {

  }

  finally
  {
    Count5reader.Close();
  }
}

<hr></hr>
<h3>Average readiness value: </h3>
@{
  var count6QueryString = "SELECT AVG(Readiness) as 'Average Readiness' FROM Responses";
  SqlCommand Count6command = new SqlCommand(count6QueryString, database);
  SqlDataReader Count6reader = Count6command.ExecuteReader();

  try
  {
    while(Count6reader.Read())
    {
      <h5>@Count6reader[0]</h5>
    }
  }

  catch
  {

  }

  finally
  {
    Count6reader.Close();
    database.Close();
  }
}
</body>
