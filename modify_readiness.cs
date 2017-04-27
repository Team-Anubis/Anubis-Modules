@using DotNetNuke.Common;
@using System;
@using DotNetNuke.Entities.Modules;
@using System.Data.SqlClient;
@using System.Diagnostics;
@using System.Data;
@using System.Data.Common;

@*Copyright (c) 2017 by Anubis *@

<body>

  <form method="post">
    @{
      var ConnectionString = DotNetNuke.Common.Utilities.Config.GetConnectionString();

      var database = new SqlConnection(ConnectionString);

      database.Open();

      SqlCommand cmd = new SqlCommand();

      SqlDataReader reader2;

      cmd.CommandText = "Select * From readiness_Value";

      cmd.CommandType = CommandType.Text;

      cmd.Connection = database;

      reader2 = cmd.ExecuteReader();

      try
      {
        while(reader2.Read()){

          <label for="readiness_Value_Perfect">Perfect Value:</label>
          <br></br>
          <input type="number" name="readiness_Value_Perfect" value="@reader2[1]"  size="100%" maxlenght="255" required/>
          <br></br>
          <label for="readiness_Value_Great">Great Value:</label>
          <br></br>
          <input type="number" name="readiness_Value_Great" value="@reader2[2]"  size="100%" maxlenght="255" required/>
          <br></br>
          <label for="readiness_Value_Good">Good Value:</label>
          <br></br>
          <input type="number" name="readiness_Value_Good" value="@reader2[3]"  size="100%" maxlenght="255" required/>
          <br></br>
          <label for="readiness_Value_Okay">Okay Value:</label>
          <br></br>
          <input type="number" name="readiness_Value_Okay" value="@reader2[4]"  size="100%" maxlenght="255" required/>
          <br></br>
          <label for="readiness_Value_Neutral">Neutral Value:</label>
          <br></br>
          <input type="number" name="readiness_Value_Neutral" value="@reader2[5]"  size="100%" maxlenght="255" required/>
          <br></br>
          <label for="readiness_Value_Flag">Flag Value:</label>
          <br></br>
          <input type="number" name="readiness_Value_Flag" value="@reader2[6]"  size="100%" maxlenght="255" required/>
          <br></br>
          <label for="readiness_Value_Yellow_Flag">Yellow Flag Value:</label>
          <br></br>
          <input type="number" name="readiness_Value_Yellow_Flag" value="@reader2[7]"  size="100%" maxlenght="255" required/>
          <br></br>
          <label for="readiness_Value_Red_Flag">Red Flag Value:</label>
          <br></br>
          <input type="number" name="readiness_Value_Red_Flag" value="@reader2[8]"  size="100%" maxlenght="255" required/>
          <br></br>
          <label for="readiness_Value_Restrict">Restrict Value:</label>
          <br></br>
          <input type="number" name="readiness_Value_Restrict" value="@reader2[9]"  size="100%" maxlenght="255" required/>
          <br></br>

        }

    }
    catch
    {

    }
    finally
    {
      // Always call Close when done reading.
      <input type="submit"  class="btn btn-success btn-lg" name="Update" value="Update Values"/>
      reader2.Close();

    }
  }

  @{

    int readiness_Value_Perfect = 0;
    int readiness_Value_Great = 0;
    int readiness_Value_Good = 0;
    int readiness_Value_Okay = 0;
    int readiness_Value_Neutral = 0;
    int readiness_Value_Flag = 0;
    int readiness_Value_Yellow_Flag = 0;
    int readiness_Value_Red_Flag = 0;
    int readiness_Value_Restrict = 0;

    if(IsPost)
    {
      try
      {
        readiness_Value_Perfect = Convert.ToInt32(Request.Form["readiness_Value_Perfect"]);
        readiness_Value_Great = Convert.ToInt32(Request.Form["readiness_Value_Great"]);
        readiness_Value_Good = Convert.ToInt32(Request.Form["readiness_Value_Good"]);
        readiness_Value_Okay = Convert.ToInt32(Request.Form["readiness_Value_Okay"]);
        readiness_Value_Neutral = Convert.ToInt32(Request.Form["readiness_Value_Neutral"]);
        readiness_Value_Flag = Convert.ToInt32(Request.Form["readiness_Value_Flag"]);
        readiness_Value_Yellow_Flag = Convert.ToInt32(Request.Form["readiness_Value_Yellow_Flag"]);
        readiness_Value_Red_Flag = Convert.ToInt32(Request.Form["readiness_Value_Red_Flag"]);
        readiness_Value_Restrict = Convert.ToInt32(Request.Form["readiness_Value_Restrict"]);

        SqlCommand cmd2 = new SqlCommand();

        SqlDataReader reader3;

        cmd2.Parameters.AddWithValue("@1", readiness_Value_Perfect);
        cmd2.Parameters.AddWithValue("@2", readiness_Value_Great);
        cmd2.Parameters.AddWithValue("@3", readiness_Value_Good);
        cmd2.Parameters.AddWithValue("@4", readiness_Value_Okay);
        cmd2.Parameters.AddWithValue("@5", readiness_Value_Neutral);
        cmd2.Parameters.AddWithValue("@6", readiness_Value_Flag);
        cmd2.Parameters.AddWithValue("@7", readiness_Value_Yellow_Flag);
        cmd2.Parameters.AddWithValue("@8", readiness_Value_Red_Flag);
        cmd2.Parameters.AddWithValue("@9", readiness_Value_Restrict);

        cmd2.CommandText = "UPDATE readiness_Value SET readiness_Value_Perfect = @1, readiness_Value_Great = @2, readiness_Value_Good = @3, readiness_Value_Okay = @4, readiness_Value_Neutral = @5, readiness_Value_Flag = @6, readiness_Value_Yellow_Flag = @7, readiness_Value_Red_Flag = @8, readiness_Value_Restrict = @9 WHERE (readiness_Value_ID = 1)";

        cmd2.CommandType = CommandType.Text;

        cmd2.Connection = database;

        reader3 = cmd2.ExecuteReader();

        reader3.Close();
        database.Close();

      }

      catch
      {

      }
      finally
      {
        Response.Redirect("http://petready.org.nau.edu/Administrator-Account/manage-readiness");
      }

    }
  }

  </form>

</body>
