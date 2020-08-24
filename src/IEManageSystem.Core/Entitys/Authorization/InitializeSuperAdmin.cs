﻿using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using Castle.Core.Logging;
using IEManageSystem.Entitys.Authorization.Permissions;
using IEManageSystem.Entitys.Authorization.Roles;
using IEManageSystem.Entitys.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UtilityAction.Other;

namespace IEManageSystem.Entitys.Authorization
{
    public class InitializeSuperAdmin:IDomainService
    {
        public ILogger Logger { get; set; }

        private IUnitOfWorkManager _unitOfWorkManager { get; set; }

        private UserManager _userManager { get; set; }

        private RoleManager _roleManager { get; set; }

        private PermissionManager _permissionManager { get; set; }

        public InitializeSuperAdmin(
            UserManager userManager,
            RoleManager roleManager,
            IUnitOfWorkManager unitOfWorkManager,
            PermissionManager permissionManager)
        {
            Logger = NullLogger.Instance;

            _userManager = userManager;

            _roleManager = roleManager;

            _unitOfWorkManager = unitOfWorkManager;

            _permissionManager = permissionManager;
        }

        public void Initialize()
        {
            if (_userManager.UserRepository.Count() > 0) {
                return;
            }

            using (var unitOfWork = _unitOfWorkManager.Begin())
            {
                try
                {
                    var superPermission = Permission.SuperPermission;
                    _permissionManager.PermissionRepository.Insert(superPermission);

                    var adminPermission = Permission.AdminPermission;
                    _permissionManager.PermissionRepository.Insert(adminPermission);

                    var userPermission = Permission.UserPermission;
                    _permissionManager.PermissionRepository.Insert(userPermission);

                    _unitOfWorkManager.Current.SaveChanges();


                    var superAdminRole = Role.SuperAdmin;
                    superAdminRole.RolePermissions = new List<RolePermission>();
                    superAdminRole.AddPermission(superPermission);
                    _roleManager.RoleRepository.Insert(superAdminRole);

                    var adminRole = Role.Admin;
                    adminRole.RolePermissions = new List<RolePermission>();
                    adminRole.AddPermission(adminPermission);
                    _roleManager.RoleRepository.Insert(adminRole);


                    var userRole = Role.User;
                    userRole.RolePermissions = new List<RolePermission>();
                    userRole.AddPermission(userPermission);
                    _roleManager.RoleRepository.Insert(userRole);

                    _unitOfWorkManager.Current.SaveChanges();


                    User superAdmin = _userManager.CreateUser("SuperAdmin", "123456", "超级管理员").Result;
                    superAdmin.AddRole(superAdminRole);

                    _unitOfWorkManager.Current.SaveChanges();

                    unitOfWork.Complete();
                }
                catch(Exception ex)
                {
                    Logger.Error(ex.Message);
                    throw ex;
                }
            }
        }
    }
}
