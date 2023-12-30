insert into users (Username, Password)
  values ('testAdmin', 'admin');

insert into UserRoles (UserId, RoleId)
  values ((select Id from Users where Username = 'testAdmin'), 'Admin');