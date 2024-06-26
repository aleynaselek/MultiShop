﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
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
                new ApiResource("ResourceOrder") { Scopes = { "OrderFullPermission" } },
                new ApiResource("ResourceCargo") { Scopes = { "CargoFullPermission" } },
                new ApiResource("ResourceBasket") { Scopes = { "BasketFullPermission" } },
                new ApiResource("ResourceComment") { Scopes = { "CommentFullPermission" } },
                new ApiResource("ResourcePayment") { Scopes = { "PaymentFullPermission" } },
                new ApiResource("ResourceImages") { Scopes = { "ImagesFullPermission" } },
                new ApiResource("ResourceOcelot") { Scopes = { "OcelotFullPermission" } },
                new ApiResource("ResourceMessage"){Scopes={"MessageFullPermission"} },
                new ApiResource(IdentityServerConstants.LocalApi.ScopeName)

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
            new ApiScope("CargoFullPermission", "Full permission for cargo API"),
            new ApiScope("BasketFullPermission", "Full permission for basket API"),
            new ApiScope("CommentFullPermission", "Full permission for comment API"),
            new ApiScope("PaymentFullPermission", "Full permission for payment API"),
            new ApiScope("ImagesFullPermission", "Full permission for images API"),
            new ApiScope("OcelotFullPermission", "Full permission for ocelot API"),
            new ApiScope("MessageFullPermission","Full authority for message operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName) 
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client
            {
                ClientId = "MultiShopVisitorId",
                ClientName = "Multi Shop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets ={ new Secret("multishopsecret".Sha256()) },
                AllowedScopes = { "CatalogReadPermission", "CatalogFullPermission", "OcelotFullPermission", "CommentFullPermission", "ImagesFullPermission" , "BasketFullPermission",IdentityServerConstants.LocalApi.ScopeName }
            },
            
            //Manager 
            new Client
            {
                ClientId = "MultiShopManagerId",
                ClientName = "Multi Shop Manager User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets ={ new Secret("multishopsecret".Sha256()) },
                AllowedScopes = { "CatalogFullPermission", "CatalogReadPermission", "BasketFullPermission", "OcelotFullPermission", "CommentFullPermission", "PaymentFullPermission", "ImagesFullPermission","DiscountFullPermission","OrderFullPermission", "MessageFullPermission","CargoFullPermission",
                 IdentityServerConstants.LocalApi.ScopeName,
                 IdentityServerConstants.StandardScopes.Email,
                 IdentityServerConstants.StandardScopes.OpenId,
                 IdentityServerConstants.StandardScopes.Profile } 
            },
            
            //Admin
            new Client
            {
                ClientId = "MultiShopAdminId",
                ClientName = "Multi Shop Admin User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets ={ new Secret("multishopsecret".Sha256()) },
                AllowedScopes = { "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission", "OrderFullPermission","CargoFullPermission","BasketFullPermission","OcelotFullPermission", "CommentFullPermission" , "PaymentFullPermission", "ImagesFullPermission",
                 IdentityServerConstants.LocalApi.ScopeName,
                 IdentityServerConstants.StandardScopes.Email,
                 IdentityServerConstants.StandardScopes.OpenId,
                 IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime = 600
            }
        };
    }
}