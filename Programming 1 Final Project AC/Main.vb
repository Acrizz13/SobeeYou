'Aleksander Chrismer
'Programming 1 Final Project
'Due 08/20/2022 @ 6am



Public Class Main


    Private Sub btnExit_Click(sender As Object, e As EventArgs) 

        'close
        Close()

    End Sub

    Private Sub btnSalary_Click(sender As Object, e As EventArgs) 
        'If user clicks salary button, run salary form
        Dim Salary As New frmSalary

        Salary.ShowDialog()
    End Sub

    Private Sub btnHourly_Click(sender As Object, e As EventArgs) 
        'If user clicks hourly button, run hourly form

        Dim Hourly As New frmHourly
        Hourly.ShowDialog()

    End Sub



    Private Sub SalaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalaryToolStripMenuItem.Click
        'Call salary button
        btnSalary_Click(sender, e)
    End Sub

    Private Sub HourlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HourlyToolStripMenuItem.Click
        'Call hourly button

        btnHourly_Click(sender, e)
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        'call exit button
        btnExit_Click(sender, e)
    End Sub


End Class
