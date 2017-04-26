@using DotNetNuke.Common;
@using System;
@using DotNetNuke.Entities.Modules;
@using System.Data.SqlClient;
@using System.Diagnostics;
@using System.Data;
@using System.Data.Common;

@*Copyright (c) 2017 by Anubis *@

<body>
  <form>
    <h2>Select a shelter to modify</h2>
    <select name="selection_id">

      @{

        string selection = Request.Form["selection_id"];

        var ConnectionString = DotNetNuke.Common.Utilities.Config.GetConnectionString();

        var database = new SqlConnection(ConnectionString);

        var selectAllString = "SELECT * FROM partnered_Shelter ORDER BY partnered_Shelters_ID";

        SqlCommand command = new SqlCommand(selectAllString, database);

        database.Open();

        var databaseName = database.Database;

        SqlDataReader reader = command.ExecuteReader();

        try
        {
          while (reader.Read())
          {

            <option value="@reader[0]">@reader[0]: @reader[1]</option>

          }

        }

        finally
        {
          // Always call Close when done reading.
          reader.Close();

        }
      }
    </select>
    <br></br>
    <button  class="btn btn-success btn-lg" onserverclick="Button_Click" runat="server"/>Select</button>
  </form>


  <form method="post">
    @{
      SqlCommand cmd = new SqlCommand();

      SqlDataReader reader2;

      cmd.Parameters.Add(new SqlParameter("@1", string.IsNullOrEmpty(selection) ? (object)DBNull.Value : selection));

      cmd.CommandText = "SELECT * FROM partnered_Shelter WHERE partnered_Shelters_ID = @1";

      cmd.CommandType = CommandType.Text;

      cmd.Connection = database;

      reader2 = cmd.ExecuteReader();

      try
      {
        while(reader2.Read()){

          <input type="hidden" name="current_selection" value="@reader2[0]" size="100%" />

          <label for="partnered_Shelter_Name">Shelter Name:</label>
          <br></br>
          <input type="text" name="partnered_Shelter_Name" value="@reader2[1]" size="100%" maxlenght="255" required/>
          <br></br>

          <label for="partnered_Shelter_Email">Shelter Email:</label>
          <br></br>
          <input type="email" name="partnered_Shelter_Email" value="@reader2[2]"  size="100%" maxlenght="255"/>
          <br></br>

          <input type="submit"  class="btn btn-success btn-lg" name="Update" value="Update Shelter"/>

        }

    }
    finally
    {
      // Always call Close when done reading.

      reader2.Close();

    }
  }
  @{

    string current_selection = "";
    string partnered_Shelter_Name = "";
    string partnered_Shelter_Email = "";

    <h1>@partnered_Shelter_Email</h1>

    if(IsPost)
    {
      current_selection = Request.Form["current_selection"];
      partnered_Shelter_Name = Request.Form["partnered_Shelter_Name"];
      partnered_Shelter_Email = Request.Form["partnered_Shelter_Email"];

      try
      {

        SqlCommand cmd2 = new SqlCommand();

        SqlDataReader reader3;

        cmd2.Parameters.Add(new SqlParameter("@1", string.IsNullOrEmpty(partnered_Shelter_Name) ? (object)DBNull.Value : partnered_Shelter_Name));
        cmd2.Parameters.Add(new SqlParameter("@2", string.IsNullOrEmpty(partnered_Shelter_Email) ? (object)DBNull.Value : partnered_Shelter_Email));
        cmd2.Parameters.Add(new SqlParameter("@3", string.IsNullOrEmpty(current_selection) ? (object)DBNull.Value : current_selection));

        cmd2.CommandText = "UPDATE partnered_Shelter SET partnered_Shelter_Name = @1, partnered_Shelter_Email = @2 WHERE (partnered_Shelters_ID = @3)";

        cmd2.CommandType = CommandType.Text;

        cmd2.Connection = database;

        reader3 = cmd2.ExecuteReader();

        database.Close();

      }

      finally
      {

      }
    }
  }

  </form>

</body>
