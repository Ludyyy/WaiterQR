Create procedure[dbo].[AddNewRestaurantsDetails]
    (   
        @Restaurant_Id int,
        @Owner_LastName varchar (50),  
        @Owner_FirstName varchar(50),  
        @Restaurant_City varchar(50),
        @Restaurant_PostalCode int,
        @Restaurant_StreetName varchar(50)
    )  
    as  
    begin
   Insert into Restaurants values(@Restaurant_Id, @Owner_LastName, @Owner_FirstName, @Restaurant_City,@Restaurant_PostalCode,@Restaurant_StreetName )
  End