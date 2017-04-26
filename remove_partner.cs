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
    <h2>Select a shelter to delete</h2>
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
        catch
        {

        }

        finally
        {
          // Always call Close when done reading.
          reader.Close();


        }
      }
    </select>
    <br></br>
    <button type="submit" onserverclick="Button_Click" runat="server" class="btn btn-danger btn-lg" />Remove</button>
  </form>

@{
  if(IsPost)
  {
    try
    {
      SqlCommand cmd = new SqlCommand();

      SqlDataReader reader2;

      cmd.Parameters.Add(new SqlParameter("@1", string.IsNullOrEmpty(selection) ? (object)DBNull.Value : selection));

      cmd.CommandText = "DELETE FROM partnered_Shelter WHERE partnered_Shelters_ID = @1";

      cmd.CommandType = CommandType.Text;

      cmd.Connection = database;

      reader2 = cmd.ExecuteReader();



    }
    catch
    {

    }
    finally
    {
      database.Close();
      Response.Redirect("http://petready.org.nau.edu/Administrator-Account/Remove-Shelter");
    }
  }
}
</body>
