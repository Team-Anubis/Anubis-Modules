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
    <fieldset>
      <h2>Add A New Partnered Shelter</h2>
      <div>
        <label for="Question">Shelter Name:<span style="color:red">*</span></label>
        <br></br>
        <input type="text" name="Shelter_Name" value="" size="100%" maxlenght="255" required />
        <br></br>
      </div>
      <div>
        <label for="Question">Shelter email:<span style="color:red">*</span></label>
        <br></br>
        <input type="email" name="Shelter_email" value="" size="100%" maxlenght="255" required/>
        <br></br>
      </div>
    <input type="submit" class="btn btn-success btn-lg" name="Insert" value="Add Shelter"/>
    </feldset>
  </form>



@{

  string Shelter_Name = "";
  string Shelter_email = "";
  string body = "Congratulations you have been added as a partnered shelter to the PetReady website. If you feel this is a mistake please contact the webmaster at petready.webmaster@gmail.com.";
  string subject = "Added as PetReady partner";


  if(IsPost){

    Shelter_Name = Request.Form["Shelter_Name"];
    Shelter_email = Request.Form["Shelter_email"];

    <h3>You just added, and confirmation email has been sent</h3>
    <p>
      Shelter Name: @Shelter_Name <br></br>
      Shelter Email: @Shelter_email <br></br>
    </p>


    try
    {

      var ConnectionString = DotNetNuke.Common.Utilities.Config.GetConnectionString();
      SqlConnection database = new SqlConnection(ConnectionString);
      var databaseName = database.Database;
      SqlCommand cmd = new SqlCommand();
      SqlDataReader reader;

      cmd.Parameters.Add(new SqlParameter("@1", string.IsNullOrEmpty(Shelter_Name) ? (object)DBNull.Value : Shelter_Name));
      cmd.Parameters.Add(new SqlParameter("@2", string.IsNullOrEmpty(Shelter_email) ? (object)DBNull.Value : Shelter_email));


      cmd.CommandText = "INSERT INTO partnered_Shelter (partnered_Shelter_Name, partnered_Shelter_Email) VALUES (@1,@2)";


      cmd.CommandType = CommandType.Text;


      cmd.Connection = database;

      database.Open();

      reader = cmd.ExecuteReader();

      database.Close();

    }
    finally
    {

      DotNetNuke.Services.Mail.Mail.SendEmail("petready.webmaster@gmail.com", Shelter_email, subject, body);

    }

  }
}


</body>
