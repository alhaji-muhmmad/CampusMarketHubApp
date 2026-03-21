# Campus Market Hub — UI Style Guide

> Based on the "Exclusive" e-commerce design system.
> Every screen in the project must follow these guidelines to ensure visual consistency across all 46 forms.

---

## Table of Contents

1. [Color Palette](#1-color-palette)
2. [Typography](#2-typography)
3. [Form Controls](#3-form-controls)
4. [Buttons](#4-buttons)
5. [Layout & Spacing](#5-layout--spacing)
6. [Cards & Panels](#6-cards--panels)
7. [Navigation & Sidebars](#7-navigation--sidebars)
8. [Status & Feedback](#8-status--feedback)
9. [DataGridView Style](#9-datagridview-style)
10. [Screen Templates](#10-screen-templates)

---

## 1. Color Palette

These are the ONLY colors used across the entire application.

| Role | Name | Hex Code | Usage |
|---|---|---|---|
| **Primary** | Red | `#DB4444` | Main buttons, active states, alerts, badges |
| **Primary Hover** | Dark Red | `#C13333` | Button hover state |
| **Background** | White | `#FFFFFF` | Main form/panel backgrounds |
| **Page Background** | Off-White | `#F5F5F5` | Window/outer background |
| **Dark Surface** | Near Black | `#1A1A1A` | Footer panels, dark sidebars |
| **Text Primary** | Black | `#000000` | Headings, bold labels |
| **Text Secondary** | Dark Gray | `#333333` | Body text, regular labels |
| **Text Muted** | Medium Gray | `#7D8184` | Placeholder text, subtitles, hints |
| **Border** | Light Gray | `#E0E0E0` | Input borders, dividers, card borders |
| **Disabled** | Gray | `#BDBDBD` | Disabled controls |
| **Success** | Green | `#00A651` | Success messages, completed status |
| **Warning** | Amber | `#FFAD33` | Star ratings, warnings |
| **Price Old** | Gray Strikethrough | `#9E9E9E` | Original price (crossed out) |

---

## 2. Typography

**Font Family:** `Poppins` or `Segoe UI` (Segoe UI is pre-installed on all Windows machines — use this as the fallback)

### Font Sizes

| Element | Size | Weight | Color |
|---|---|---|---|
| Screen Title (H1) | `24px` / `18pt` | Bold | `#000000` |
| Section Heading (H2) | `20px` / `15pt` | SemiBold | `#000000` |
| Sub-heading (H3) | `16px` / `12pt` | SemiBold | `#333333` |
| Body / Labels | `14px` / `10.5pt` | Regular | `#333333` |
| Small / Hints | `12px` / `9pt` | Regular | `#7D8184` |
| Placeholder Text | `14px` / `10.5pt` | Regular | `#BDBDBD` |

### Applying Fonts in VB.NET

```vb
' Screen title
lblTitle.Font = New Font("Segoe UI", 18, FontStyle.Bold)
lblTitle.ForeColor = Color.FromArgb(0, 0, 0)

' Section heading
lblSectionName.Font = New Font("Segoe UI", 13, FontStyle.Bold)

' Body label
lblUsername.Font = New Font("Segoe UI", 10, FontStyle.Regular)
lblUsername.ForeColor = Color.FromArgb(51, 51, 51)

' Hint / muted text
lblHint.Font = New Font("Segoe UI", 9, FontStyle.Regular)
lblHint.ForeColor = Color.FromArgb(125, 129, 132)
```

---

## 3. Form Controls

### TextBox Style (Bottom-border only — matches design)

```vb
' Apply this to every TextBox in the project
txtInput.BorderStyle = BorderStyle.None
txtInput.Font = New Font("Segoe UI", 10, FontStyle.Regular)
txtInput.ForeColor = Color.FromArgb(51, 51, 51)
txtInput.BackColor = Color.White
txtInput.Height = 30

' Draw bottom border using the form's Paint event or a Panel underline trick:
' Place a 1px-height Panel directly below the TextBox
' Set Panel BackColor = Color.FromArgb(224, 224, 224)  ← #E0E0E0
```

### ComboBox Style

```vb
cboInput.FlatStyle = FlatStyle.Flat
cboInput.Font = New Font("Segoe UI", 10, FontStyle.Regular)
cboInput.ForeColor = Color.FromArgb(51, 51, 51)
cboInput.BackColor = Color.White
```

### DataGridView — see Section 9

---

## 4. Buttons

### Primary Button (Red — main action)

```vb
btnPrimary.FlatStyle = FlatStyle.Flat
btnPrimary.FlatAppearance.BorderSize = 0
btnPrimary.BackColor = Color.FromArgb(219, 68, 68)     ' #DB4444
btnPrimary.ForeColor = Color.White
btnPrimary.Font = New Font("Segoe UI", 10, FontStyle.Regular)
btnPrimary.Cursor = Cursors.Hand
btnPrimary.Size = New Size(280, 44)

' Hover effect — add MouseEnter/MouseLeave events:
Private Sub btnPrimary_MouseEnter(sender As Object, e As EventArgs)
    btnPrimary.BackColor = Color.FromArgb(193, 51, 51)  ' #C13333
End Sub
Private Sub btnPrimary_MouseLeave(sender As Object, e As EventArgs)
    btnPrimary.BackColor = Color.FromArgb(219, 68, 68)  ' #DB4444
End Sub
```

### Secondary Button (White with border — secondary action)

```vb
btnSecondary.FlatStyle = FlatStyle.Flat
btnSecondary.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224)
btnSecondary.FlatAppearance.BorderSize = 1
btnSecondary.BackColor = Color.White
btnSecondary.ForeColor = Color.FromArgb(51, 51, 51)
btnSecondary.Font = New Font("Segoe UI", 10, FontStyle.Regular)
btnSecondary.Cursor = Cursors.Hand
btnSecondary.Size = New Size(280, 44)
```

### Link Button (Red text — e.g. "Forgot Password?")

```vb
' Use a Label, not a Button
lblLink.ForeColor = Color.FromArgb(219, 68, 68)
lblLink.Font = New Font("Segoe UI", 10, FontStyle.Regular)
lblLink.Cursor = Cursors.Hand
lblLink.AutoSize = True
' No underline by default — matches the design
```

---

## 5. Layout & Spacing

### Standard Margins & Padding

| Element | Value |
|---|---|
| Form outer padding | `40px` on all sides |
| Between label and its input | `8px` |
| Between input fields (vertical gap) | `24px` |
| Between sections | `40px` |
| Button top margin (from last input) | `32px` |
| Card internal padding | `24px` |

### Split Layout (Auth screens — Login, Sign Up)

```
┌─────────────────────────────────────────────┐
│  LEFT PANEL (40% width)   │  RIGHT PANEL    │
│  Background image /       │  (60% width)    │
│  illustration panel       │  Form content   │
│  Color: #F5F5F5 or image  │  Background: #FFF│
└─────────────────────────────────────────────┘
```

- Left panel: decorative image or colored panel (`#F5F5F5`)
- Right panel: white, contains the form centered vertically
- Form content starts at roughly `Y = 120px` from top of right panel

### Dashboard Layout (Vendor, Buyer, Admin)

```
┌──────────────────────────────────────────────┐
│  TOP NAV BAR  (full width, height: 70px)     │
├──────────┬───────────────────────────────────┤
│ SIDEBAR  │  MAIN CONTENT AREA               │
│ 220px    │  Remaining width                 │
│ #1A1A1A  │  Background: #F5F5F5             │
│ (dark)   │  Padding: 24px                   │
└──────────┴───────────────────────────────────┘
```

---

## 6. Cards & Panels

### White Content Card

```vb
' Use a Panel as a card
pnlCard.BackColor = Color.White
pnlCard.Padding = New Padding(24)
' Add a subtle border:
' Draw border in Panel's Paint event or use BorderStyle.FixedSingle with light gray
```

Card properties:
- Background: `#FFFFFF`
- Border: `1px solid #E0E0E0`
- Internal padding: `24px`
- No rounded corners needed (Windows Forms panels are square by default)

### Dark Panel (Footer / Sidebar)

```vb
pnlDark.BackColor = Color.FromArgb(26, 26, 26)   ' #1A1A1A
' Text inside dark panels:
lblDarkText.ForeColor = Color.White
lblDarkMuted.ForeColor = Color.FromArgb(189, 189, 189)
```

---

## 7. Navigation & Sidebars

### Top Navigation Bar

```vb
pnlTopNav.BackColor = Color.White
pnlTopNav.Height = 70
' Add a bottom border line using a 1px Panel:
' pnlNavBorder.Height = 1
' pnlNavBorder.BackColor = Color.FromArgb(224, 224, 224)

' Brand/Logo label:
lblBrand.Font = New Font("Segoe UI", 16, FontStyle.Bold)
lblBrand.ForeColor = Color.FromArgb(0, 0, 0)
lblBrand.Text = "Campus Market Hub"

' Nav links (inactive):
lblNavItem.Font = New Font("Segoe UI", 10, FontStyle.Regular)
lblNavItem.ForeColor = Color.FromArgb(51, 51, 51)
lblNavItem.Cursor = Cursors.Hand

' Nav link (active/selected):
lblNavItemActive.Font = New Font("Segoe UI", 10, FontStyle.Regular)
lblNavItemActive.ForeColor = Color.FromArgb(219, 68, 68)   ' Red = active
```

### Dark Sidebar

```vb
pnlSidebar.BackColor = Color.FromArgb(26, 26, 26)
pnlSidebar.Width = 220

' Sidebar menu item (inactive):
lblMenuItem.Font = New Font("Segoe UI", 10, FontStyle.Regular)
lblMenuItem.ForeColor = Color.FromArgb(189, 189, 189)
lblMenuItem.Cursor = Cursors.Hand

' Sidebar menu item (active):
lblMenuItemActive.Font = New Font("Segoe UI", 10, FontStyle.Regular)
lblMenuItemActive.ForeColor = Color.White
' Add a left red accent bar (1px Panel, BackColor = #DB4444, docked left)
```

---

## 8. Status & Feedback

### Inline Error (below input field)

```vb
lblError.ForeColor = Color.FromArgb(219, 68, 68)   ' Red
lblError.Font = New Font("Segoe UI", 9, FontStyle.Regular)
lblError.Text = "Invalid username or password."
```

### Success Message

```vb
lblSuccess.ForeColor = Color.FromArgb(0, 166, 81)  ' Green
lblSuccess.Font = New Font("Segoe UI", 9, FontStyle.Regular)
lblSuccess.Text = "Order placed successfully."
```

### Status Badges (Order status, etc.)

| Status | Background | Text Color |
|---|---|---|
| Pending | `#FFF3E0` | `#E65100` |
| Completed | `#E8F5E9` | `#1B5E20` |
| Cancelled | `#FFEBEE` | `#B71C1C` |

---

## 9. DataGridView Style

Apply this to every DataGridView in the project for a clean, consistent table look.

```vb
Public Shared Sub StyleDataGrid(dgv As DataGridView)
    ' Overall
    dgv.BackgroundColor = Color.White
    dgv.BorderStyle = BorderStyle.None
    dgv.GridColor = Color.FromArgb(224, 224, 224)
    dgv.RowHeadersVisible = False
    dgv.AllowUserToAddRows = False
    dgv.AllowUserToDeleteRows = False
    dgv.ReadOnly = True
    dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

    ' Column headers
    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245)
    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 51, 51)
    dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
    dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
    dgv.ColumnHeadersHeight = 44
    dgv.EnableHeadersVisualStyles = False

    ' Rows
    dgv.DefaultCellStyle.BackColor = Color.White
    dgv.DefaultCellStyle.ForeColor = Color.FromArgb(51, 51, 51)
    dgv.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
    dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 235, 235)
    dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(51, 51, 51)
    dgv.RowTemplate.Height = 44

    ' Alternating row color
    dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250)
End Sub
```

Call this helper on every form that has a DataGridView:
```vb
Private Sub frmOrders_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    StyleDataGrid(dgvOrders)
    LoadOrders()
End Sub
```

---

## 10. Screen Templates

### Auth Screen Template (Login / Sign Up)

```
Form Size: 900 x 600
Form Background: #F5F5F5
FormBorderStyle: FixedSingle
StartPosition: CenterScreen

Left Panel (Panel):
  Size: 380 x 600
  BackColor: #F5F5F5
  Contains: decorative image or illustration

Right Panel (Panel):
  Size: 520 x 600
  BackColor: #FFFFFF
  Contains: form elements

  Form Title (Label):
    Font: Segoe UI, 18pt, Bold
    ForeColor: #000000
    Position: X=60, Y=80

  Subtitle (Label):
    Font: Segoe UI, 10pt, Regular
    ForeColor: #7D8184
    Position: X=60, Y=120

  Input fields start at Y=160, spaced 70px apart
  Primary button at Y=(last input + 40px)
```

### Dashboard Screen Template (Vendor / Buyer / Admin)

```
Form Size: 1280 x 800 (or maximized)
Form Background: #F5F5F5
WindowState: Maximized

Top Nav Panel:
  Height: 70px
  BackColor: #FFFFFF
  Dock: Top

Sidebar Panel:
  Width: 220px
  BackColor: #1A1A1A
  Dock: Left

Main Content Panel:
  BackColor: #F5F5F5
  Dock: Fill
  Padding: 24px
```

---

*Last updated: March 2026 — Campus Market Hub, CPT 417*
