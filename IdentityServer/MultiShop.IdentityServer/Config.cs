﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        
        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("ResourceCatalog") { Scopes = { "CatalogFullPermission", "CatalogReadPermission" } } ,
                new ApiResource("ResourceDiscount") { Scopes = { "DiscountFullPermission" } } ,
                new ApiResource("ResourceCatalog") { Scopes = { "OrderFullPermission" } } 
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission", "Full permission for catalog API"),
            new ApiScope("CatalogReadPermission", "Read permission for catalog API"),
            new ApiScope("DiscountFullPermission", "Full permission for discount API"),
            new ApiScope("OrderFullPermission", "Full permission for order API"),
        };
    }
}