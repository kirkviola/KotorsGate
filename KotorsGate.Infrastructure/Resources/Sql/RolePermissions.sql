insert into RolePermissions (RoleId, PermissionId)
  values ('Campaign Creator', 'CAMPAIGN_CREATOR');

insert into RolePermissions (RoleId, PermissionId)
  values ((select name from roles where name = 'Admin'), (select name from permissions where name = 'PLANET_CREATE'));

insert into RolePermissions (RoleId, PermissionId)
  values ('Admin', 'ADMIN_TAB');

insert into RolePermissions (RoleId, PermissionId)
  values ('Admin', 'CAMPAIGN_CREATOR');