Imports System.Net
Imports System.Net.Mail

Public Class EmailService

    ' -------------------------------------------------------
    ' SMTP Configuration
    ' Replace these with your project Gmail credentials
    ' -------------------------------------------------------
    Private Const SMTP_HOST As String = "smtp.gmail.com"
    Private Const SMTP_PORT As Integer = 587
    Private Const SENDER_EMAIL As String = "franciskolawolejoel@gmail.com"
    Private Const SENDER_PASSWORD As String = "senlwstkblrtkgrb"
    Private Const SENDER_NAME As String = "Campus Market Hub"

    ' -------------------------------------------------------
    ' SendResetCode
    ' Sends the password reset code to the user's email
    ' -------------------------------------------------------
    Public Shared Function SendResetCode(toEmail As String,
                                          username As String,
                                          resetCode As String) As Boolean
        Try
            Dim mail As New MailMessage()
            mail.From = New MailAddress(SENDER_EMAIL, SENDER_NAME)
            mail.[To].Add(toEmail)
            mail.Subject = "Your Campus Market Hub Password Reset Code"
            mail.IsBodyHtml = True
            mail.Body = BuildResetEmailBody(username, resetCode)

            Dim smtp As New SmtpClient(SMTP_HOST, SMTP_PORT)
            smtp.Credentials = New NetworkCredential(SENDER_EMAIL, SENDER_PASSWORD)
            smtp.EnableSsl = True
            smtp.Send(mail)

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function

    ' -------------------------------------------------------
    ' SendWelcomeEmail
    ' Sends a welcome email after successful registration
    ' -------------------------------------------------------
    Public Shared Function SendWelcomeEmail(toEmail As String,
                                             username As String,
                                             role As String) As Boolean
        Try
            Dim mail As New MailMessage()
            mail.From = New MailAddress(SENDER_EMAIL, SENDER_NAME)
            mail.[To].Add(toEmail)
            mail.Subject = "Welcome to Campus Market Hub!"
            mail.IsBodyHtml = True
            mail.Body = BuildWelcomeEmailBody(username, role)

            Dim smtp As New SmtpClient(SMTP_HOST, SMTP_PORT)
            smtp.Credentials = New NetworkCredential(SENDER_EMAIL, SMTP_PORT)
            smtp.EnableSsl = True
            smtp.Send(mail)

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function

    ' -------------------------------------------------------
    ' Email body builders
    ' -------------------------------------------------------
    Private Shared Function BuildResetEmailBody(username As String,
                                                 resetCode As String) As String
        Return $"
        <div style='font-family: Segoe UI, sans-serif; max-width: 500px; margin: auto;'>
            <h2 style='color: #DB4444;'>Campus Market Hub</h2>
            <p>Hi <strong>{username}</strong>,</p>
            <p>You requested a password reset. Use the code below to reset your password.</p>
            <p>This code expires in <strong>15 minutes</strong>.</p>
            <div style='background: #FFF3E0; border-left: 4px solid #DB4444;
                        padding: 16px; margin: 24px 0; text-align: center;'>
                <span style='font-size: 32px; font-weight: bold;
                             color: #DB4444; letter-spacing: 8px;'>{resetCode}</span>
            </div>
            <p style='color: #7D8184; font-size: 13px;'>
                If you did not request this, ignore this email.
                Your password will not change.
            </p>
            <hr style='border: none; border-top: 1px solid #E0E0E0; margin: 24px 0;'/>
            <p style='color: #7D8184; font-size: 12px;'>
                &copy; 2024 Campus Market Hub
            </p>
        </div>"
    End Function

    Private Shared Function BuildWelcomeEmailBody(username As String,
                                                   role As String) As String
        Return $"
        <div style='font-family: Segoe UI, sans-serif; max-width: 500px; margin: auto;'>
            <h2 style='color: #DB4444;'>Welcome to Campus Market Hub!</h2>
            <p>Hi <strong>{username}</strong>,</p>
            <p>Your account has been created successfully as a <strong>{role}</strong>.</p>
            <p>You can now log in and start using the platform.</p>
            <hr style='border: none; border-top: 1px solid #E0E0E0; margin: 24px 0;'/>
            <p style='color: #7D8184; font-size: 12px;'>
                &copy; 2024 Campus Market Hub
            </p>
        </div>"
    End Function

    Public Shared Function SendVerificationCode(toEmail As String,
                                              fullName As String,
                                              code As String) As Boolean
        Try
            Dim mail As New MailMessage()
            mail.From = New MailAddress(SENDER_EMAIL, SENDER_NAME)
            mail.[To].Add(toEmail)
            mail.Subject = "Verify your Campus Market Hub account"
            mail.IsBodyHtml = True
            mail.Body = BuildVerificationEmailBody(fullName, code)

            Dim smtp As New SmtpClient(SMTP_HOST, SMTP_PORT)
            smtp.Credentials = New NetworkCredential(SENDER_EMAIL, SENDER_PASSWORD)
            smtp.EnableSsl = True
            smtp.Send(mail)

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Shared Function BuildVerificationEmailBody(fullName As String,
                                                        code As String) As String
        Return $"
    <div style='font-family: Segoe UI, sans-serif; max-width: 500px; margin: auto;'>
        <h2 style='color: #DB4444;'>Campus Market Hub</h2>
        <p>Hi <strong>{fullName}</strong>,</p>
        <p>Thanks for signing up! Use the code below to verify your email address.</p>
        <p>This code expires in <strong>10 minutes</strong>.</p>
        <div style='background: #FFF3E0; border-left: 4px solid #DB4444;
                    padding: 16px; margin: 24px 0; text-align: center;'>
            <span style='font-size: 36px; font-weight: bold;
                         color: #DB4444; letter-spacing: 8px;'>{code}</span>
        </div>
        <p style='color: #7D8184; font-size: 13px;'>
            If you did not create this account, ignore this email.
        </p>
        <hr style='border: none; border-top: 1px solid #E0E0E0; margin: 24px 0;'/>
        <p style='color: #7D8184; font-size: 12px;'>
            &copy; 2024 Campus Market Hub
        </p>
    </div>"
    End Function

End Class