# Campus Market Hub — Coding Guidelines & Naming Conventions

> **All team members must follow these guidelines.**
> Any deviation must be approved by the project coordinator before implementation.

---

## Table of Contents

1. [Control Naming Conventions](#1-control-naming-conventions)
2. [Variable & Parameter Naming](#2-variable--parameter-naming)
3. [Functions & Subroutines](#3-functions--subroutines)
4. [Classes & Modules](#4-classes--modules)
5. [Constants](#5-constants)
6. [Database Parameters](#6-database-parameters)
7. [Form Naming](#7-form-naming)
8. [Coding Rules](#8-coding-rules)

---

## 1. Control Naming Conventions

Every control name must include a **prefix** that identifies its type, followed by a descriptive name in PascalCase.

| Control Type | Prefix | Example |
|---|---|---|
| Label | `lbl` | `lblUsername` |
| TextBox | `txt` | `txtUsername` |
| Button | `btn` | `btnLogin` |
| ComboBox | `cbo` | `cboCategory` |
| ListBox | `lst` | `lstProducts` |
| DataGridView | `dgv` | `dgvOrders` |
| PictureBox | `pic` | `picProductImage` |
| Panel | `pnl` | `pnlSidebar` |
| GroupBox | `grp` | `grpFilters` |
| CheckBox | `chk` | `chkRememberMe` |
| RadioButton | `rdb` | `rdbCash` |
| DateTimePicker | `dtp` | `dtpOrderDate` |
| Timer | `tmr` | `tmrNotification` |
| TabControl | `tab` | `tabDashboard` |
| MenuStrip | `mnu` | `mnuMain` |

---

## 2. Variable & Parameter Naming

Use **camelCase** — first word lowercase, each following word capitalized.

```vb
Dim userId As Integer
Dim productName As String
Dim totalAmount As Decimal
Dim isLoggedIn As Boolean
```

---

## 3. Functions & Subroutines

Use **PascalCase** — every word capitalized.

```vb
Public Sub LoadProducts()
Public Function GetUserById(userId As Integer) As DataRow
Private Sub ClearForm()
Private Function ValidateInput() As Boolean
```

---

## 4. Classes & Modules

Use **PascalCase**, named clearly after what they represent.

```vb
Public Class DataAccess
Public Class SessionManager
Public Class LogManager
Public Class ProductModel
```

---

## 5. Constants

Use **ALL_CAPS** with underscores.

```vb
Const MAX_LOGIN_ATTEMPTS As Integer = 3
Const DEFAULT_ROLE As String = "Buyer"
```

---

## 6. Database Parameters

Always prefix with `@`, matching the column name exactly.

```vb
New SqlParameter("@userId", userId)
New SqlParameter("@productName", productName)
```

---

## 7. Form Naming

Forms are named by their function in **PascalCase** with the `frm` prefix.

| Screen | Form Name |
|---|---|
| Login | `frmLogin.vb` |
| Sign Up | `frmSignUp.vb` |
| Vendor Dashboard | `frmVendorDashboard.vb` |
| Buyer Dashboard | `frmBuyerDashboard.vb` |
| Admin Dashboard | `frmAdminDashboard.vb` |
| Shopping Cart | `frmCart.vb` |
| Checkout | `frmCheckout.vb` |
| Order Confirmation | `frmOrderConfirmation.vb` |
| User Management | `frmUserManagement.vb` |
| Product Listing | `frmProductListing.vb` |

---

## 8. Coding Rules

### Rule 1 — Never Connect to the Database Directly from a Form

All database operations go through the `DataAccess` class. No form should ever contain a `SqlConnection`.

```vb
' ✅ CORRECT
Dim result As DataTable = DataAccess.ExecuteQuery("SELECT * FROM Products")

' ❌ WRONG — never do this inside a form
Dim conn As New SqlConnection("Server=...")
```

---

### Rule 2 — Always Use Parameterized Queries

Never concatenate user input into SQL strings. This prevents SQL injection attacks.

```vb
' ✅ CORRECT
Dim sql As String = "SELECT * FROM Users WHERE username = @username"
DataAccess.ExecuteQuery(sql, New SqlParameter("@username", txtUsername.Text))

' ❌ WRONG
Dim sql As String = "SELECT * FROM Users WHERE username = '" & txtUsername.Text & "'"
```

---

### Rule 3 — Always Validate Input Before Hitting the Database

Check all inputs at the form level first, before any database call is made.

```vb
' ✅ CORRECT
If String.IsNullOrWhiteSpace(txtUsername.Text) Then
    MessageBox.Show("Username is required.")
    Return
End If
```

---

### Rule 4 — Always Log Significant Actions

Any action that creates, modifies, or deletes data must be logged via `LogManager`.

```vb
' After a successful login
LogManager.Log(SessionManager.UserId, "Login", "User logged in successfully")

' After placing an order
LogManager.Log(SessionManager.UserId, "PlaceOrder", "Order #" & orderId & " placed")
```

---

### Rule 5 — Always Wrap Database Calls in Try-Catch

Handle errors gracefully at the form level. Never let a database error crash the app silently.

```vb
Try
    DataAccess.ExecuteNonQuery(sql, params)
Catch ex As Exception
    MessageBox.Show("Something went wrong: " & ex.Message)
End Try
```

---

### Rule 6 — One Form, One Responsibility

Each form handles one task only. A login form handles login. A signup form handles signup. Never combine unrelated logic into a single form.

---

### Rule 7 — Comment Non-Obvious Code

Don't over-comment, but mark anything that isn't immediately clear.

```vb
' Deduct stock after successful purchase
DataAccess.ExecuteNonQuery(updateStock, stockParams)

' Timer polls DB every 10 seconds for new notifications
tmrNotification.Interval = 10000
tmrNotification.Start()
```

---

### Rule 8 — Never Change the Database Schema Without Coordinator Approval

The schema is locked after Day 2. Any proposed change must go through the project coordinator first. Unauthorized schema changes break everyone's code.

---

*Last updated: March 2026 | Campus Market Hub — CPT 417*
