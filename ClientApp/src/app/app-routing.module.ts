import { Page404Component } from "./authentication/page404/page404.component";
import { AuthLayoutComponent } from "./layout/app-layout/auth-layout/auth-layout.component";
import { MainLayoutComponent } from "./layout/app-layout/main-layout/main-layout.component";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { AuthGuard } from "./core/guard/auth.guard";
import { Role } from "./core/models/role";
const routes: Routes = [
  {
    path: "",
    component: MainLayoutComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: "admin",
        canActivate: [AuthGuard],
        data: {
          role: [Role.Admin, Role.SuperAdmin, Role.User, Role.Member],
        },
        loadChildren: () =>
          import("./admin/admin.module").then((m) => m.AdminModule),
      },
      {
        path: "basic-setup",
        canActivate: [AuthGuard],
        data: {
          role: [Role.Admin, Role.SuperAdmin, Role.User],
        },
        loadChildren: () =>
          import("./basic-setup/basic-setup.module").then(
            (m) => m.BasicSetupModule
          ),
      },
      {
        path: 'book-management',
        canActivate: [AuthGuard],
        data: {
          role: [Role.Admin, Role.SuperAdmin, Role.User, Role.Member],
        },
        loadChildren: () =>
          import('./book-management/book-management.module').then((m) => m.BookManagementModule),
      },

      {
        path: 'member-management',
        canActivate: [AuthGuard],
        data: {
          role: [Role.Admin, Role.SuperAdmin, Role.User],
        },
        loadChildren: () =>
          import('./member-management/member-management.module').then((m) => m.MemberManagementModule),
      },

      {
        path: 'member-demand',
        canActivate: [AuthGuard],
        data: {
          role: [Role.Member,Role.SuperAdmin],
        },
        loadChildren: () =>
          import('./member-demand/member-demand.module').then((m) => m.MemberDemandModule),
      },
      {
        path: 'event-management',
        canActivate: [AuthGuard],
        data: {
          role: [Role.Admin, Role.SuperAdmin, Role.User],
        },
        loadChildren: () =>
          import('./event-management/event-management.module').then((m) => m.EventManagementModule),
      },
      {
        path: 'helpline-management',
        canActivate: [AuthGuard],
        data: {
          role: [Role.Admin, Role.SuperAdmin, Role.User, Role.Member],
        },
        loadChildren: () =>
          import('./helpline-management/helpline-management.module').then((m) => m.HelpLineManagementModule),
      },
      {
        path: 'notification',
        canActivate: [AuthGuard],
        data: {
          role: [Role.Admin, Role.SuperAdmin, Role.User, Role.Member],
        },
        loadChildren: () =>
          import('./notification/notification.module').then((m) => m.NotificationModule),
      },
      {
        path: 'inventory-management',
        canActivate: [AuthGuard],
        data: {
          role: [Role.Admin, Role.SuperAdmin, Role.User, Role.Member],
        },
        loadChildren: () =>
          import('./inventory-management/inventory-management.module').then((m) => m.InventoryManagementModule),
      },
      {
        path: 'password',
        canActivate: [AuthGuard],
        data: {
          role: [Role.User,Role.Admin, Role.SuperAdmin,Role.Member],
        },
        loadChildren: () =>
          import('./password/password.module').then((m) => m.PasswordModule),
      },
      

      {
        path: "security",
        canActivate: [AuthGuard],
        data: {
          role: [Role.Admin, Role.SuperAdmin, Role.User],
        },
        loadChildren: () =>
          import("./security/security.module").then((m) => m.SecurityModule),
      },

      { path: "", redirectTo: "/authentication/signin", pathMatch: "full" },
      

      // Extra components
      {
        path: "extra-pages",
        loadChildren: () =>
          import("./extra-pages/extra-pages.module").then(
            (m) => m.ExtraPagesModule
          ),
      },
    ],
  },
  {
    path: "authentication",
    component: AuthLayoutComponent,
    loadChildren: () =>
      import("./authentication/authentication.module").then(
        (m) => m.AuthenticationModule
      ),
  },
  { path: "**", component: Page404Component },
];
@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: "legacy" })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
