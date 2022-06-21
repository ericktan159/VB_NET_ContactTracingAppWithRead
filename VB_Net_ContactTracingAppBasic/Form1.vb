Imports System.IO



Public Class Form1

    Dim formContent As String = ""
    'Dim vbTab As String = vbTab
    'Dim vbNewLine As String = vbNewLine
    Dim sectionNumber As Integer = 0

    Dim inputGender As String = ""
    Dim isFever_Str As String = ""
    Dim isDryCough_Str As String = ""
    Dim isSoreThroat_Str As String = ""
    Dim isTirediness_Str As String = ""


    Dim fileName As String = "App_records.txt"
    Dim currentSectionNumFile As String = "currentSectionNumber.txt"
    Dim cntrFromFile As String = ""


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dateDTP.MinDate = DateTime.Now
        dateDTP.MaxDate = DateTime.Now
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click


        If ((File.Exists(currentSectionNumFile)) And (Not File.Exists(fileName))) Then
            File.Delete(currentSectionNumFile)
        End If

        If (isFormCompled()) Then
            If (File.Exists(currentSectionNumFile)) Then
                Dim sectionFilecontent As StreamReader = File.OpenText(currentSectionNumFile)
                cntrFromFile = sectionFilecontent.ReadLine()

                sectionFilecontent.Close()
                sectionNumber = Integer.Parse(cntrFromFile)
                sectionNumber += 1
            Else
                sectionNumber = 1
                Dim sectionFileconten As StreamWriter = File.CreateText(currentSectionNumFile)
                sectionFileconten.Write(sectionNumber.ToString())
                sectionFileconten.Close()
            End If

            inputGender = If(rdBtnMale_Gender.Checked, "Male", If(rdBtnFemale_Gender.Checked, "Female", ""))
            isFever_Str = If(rdBtnYes_Fever.Checked, "Yes", If(rdBtnNo_Fever.Checked, "No", ""))
            isDryCough_Str = If(rdBtnYes_DryCough.Checked, "Yes", If(rdBtnNo_DryCough.Checked, "No", ""))
            isSoreThroat_Str = If(rdBtnYes_SoreThroat.Checked, "Yes", If(rdBtnNo_SoreThroat.Checked, "No", ""))
            isTirediness_Str = If(rdBtnYes_Tirediness.Checked, "Yes", If(rdBtnNo_Tiredines.Checked, "No", ""))

            formContent = "Section " + sectionNumber.ToString() + ": " + vbNewLine _
                            + "Name: " + vbTab + txtBxFirstName.Text + vbTab + txtBxMiddleName.Text + vbTab + txtBxLastName.Text + vbNewLine _
                            + "Age: " + vbTab + txtBxAge.Text + vbNewLine _
                            + "Contact Number: " + vbTab + txtBxContactNum.Text + vbNewLine _
                            + "E-Mail: " + vbTab + txtBxEMail.Text + vbNewLine _
                            + "Gender: " + vbTab + inputGender + vbNewLine _
                            + "Date: " + vbTab + dateDTP.Text + vbNewLine _
                            + "Barangay: " + vbTab + txtBxBarangay.Text + vbNewLine + vbNewLine _
                            + "*Health Condition" + vbTab + vbNewLine _
                            + "If Has Fever: " + vbTab + isFever_Str + vbNewLine _
                            + "If Has Dry Cough " + vbTab + isDryCough_Str + vbNewLine _
                            + "If Has Sore Throat: " + vbTab + isSoreThroat_Str + vbNewLine _
                            + "If Has Tiredines: " + vbTab + isTirediness_Str + vbNewLine + vbNewLine _
                            + "END_OF_SECTION_" + sectionNumber.ToString() + vbNewLine + vbNewLine + vbNewLine

            MessageBox.Show(formContent)

            If (File.Exists(fileName)) Then
                Dim outputFile As StreamWriter = File.AppendText(fileName)
                outputFile.WriteLine(formContent)
                outputFile.Close()

                Dim sectionFileconten As StreamWriter = File.CreateText(currentSectionNumFile)
                sectionFileconten.Write(sectionNumber.ToString())
                sectionFileconten.Close()
            Else
                Dim outputFile As StreamWriter = File.CreateText(fileName)
                outputFile.WriteLine(formContent)
                outputFile.Close()

                Dim sectionFileconten As StreamWriter = File.CreateText(currentSectionNumFile)
                sectionFileconten.Write(sectionNumber.ToString())
                sectionFileconten.Close()
            End If

            resetForm()

        Else
            ifEmptyFieldWarning()
            MessageBox.Show("Please Complete the Form")
            resestBackColor()
        End If

    End Sub



    Private Sub ifEmptyFieldWarning()

        If (txtBxFirstName.Text = "") Then
            txtBxFirstName.BackColor = Color.Red
        End If

        If (txtBxMiddleName.Text = "") Then
            txtBxMiddleName.BackColor = Color.Red
        End If

        If (txtBxLastName.Text = "") Then
            txtBxLastName.BackColor = Color.Red
        End If

        If (txtBxAge.Text = "") Then
            txtBxAge.BackColor = Color.Red
        End If

        If (txtBxContactNum.Text = "") Then
            txtBxContactNum.BackColor = Color.Red
        End If

        If (txtBxEMail.Text = "") Then
            txtBxEMail.BackColor = Color.Red
        End If

        If (txtBxBarangay.Text = "") Then
            txtBxBarangay.BackColor = Color.Red
        End If




        If (rdBtnMale_Gender.Checked = rdBtnFemale_Gender.Checked) Then
            grpBxGender.BackColor = Color.Red
        End If

        If (rdBtnYes_Fever.Checked = rdBtnNo_Fever.Checked) Then
            grpBxFever.BackColor = Color.Red
        End If

        If (rdBtnYes_DryCough.Checked = rdBtnNo_DryCough.Checked) Then
            grpBxDryCough.BackColor = Color.Red
        End If

        If (rdBtnYes_SoreThroat.Checked = rdBtnNo_SoreThroat.Checked) Then
            grpBxSoreThroat.BackColor = Color.Red
        End If

        If (rdBtnYes_Tirediness.Checked = rdBtnNo_Tiredines.Checked) Then
            grpBxTirediness.BackColor = Color.Red
        End If

    End Sub




    Private Sub resestBackColor()
        txtBxFirstName.BackColor = Color.White
        txtBxMiddleName.BackColor = Color.White
        txtBxLastName.BackColor = Color.White
        txtBxAge.BackColor = Color.White
        txtBxContactNum.BackColor = Color.White
        txtBxEMail.BackColor = Color.White
        txtBxBarangay.BackColor = Color.White


        grpBxGender.BackColor = Color.White
        grpBxFever.BackColor = Color.White
        grpBxDryCough.BackColor = Color.White
        grpBxSoreThroat.BackColor = Color.White
        grpBxTirediness.BackColor = Color.White

    End Sub




    Private Function isNotEmptyTextBoxes() As Boolean
        If (Not (txtBxFirstName.Text = "") And Not (txtBxFirstName.Text = "") And Not (txtBxMiddleName.Text = "") And Not (txtBxLastName.Text = "") And Not (txtBxAge.Text = "") And Not (txtBxContactNum.Text = "") And Not (txtBxBarangay.Text = "")) Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Function isFormCompled() As Boolean


        If ((Not (txtBxFirstName.Text = "") And Not (txtBxMiddleName.Text = "") And Not (txtBxLastName.Text = "") And Not (txtBxAge.Text = "") And Not (txtBxContactNum.Text = "") And Not (txtBxBarangay.Text = "")) _
                And (Not (rdBtnMale_Gender.Checked = rdBtnFemale_Gender.Checked) And
                Not (rdBtnYes_Fever.Checked = rdBtnNo_Fever.Checked) And Not (rdBtnYes_DryCough.Checked = rdBtnNo_DryCough.Checked) _
                And Not (rdBtnYes_SoreThroat.Checked = rdBtnNo_SoreThroat.Checked) And Not (rdBtnYes_Tirediness.Checked = rdBtnNo_Tiredines.Checked))) Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub resetForm()
        txtBxFirstName.Text = ""
        txtBxMiddleName.Text = ""
        txtBxLastName.Text = ""
        txtBxAge.Text = ""
        txtBxContactNum.Text = ""
        txtBxEMail.Text = ""
        rdBtnMale_Gender.Checked = False
        rdBtnFemale_Gender.Checked = False
        txtBxBarangay.Text = ""

        rdBtnYes_Fever.Checked = False
        rdBtnNo_Fever.Checked = False

        rdBtnYes_DryCough.Checked = False
        rdBtnNo_DryCough.Checked = False

        rdBtnYes_SoreThroat.Checked = False
        rdBtnNo_SoreThroat.Checked = False

        rdBtnYes_Tirediness.Checked = False
        rdBtnNo_Tiredines.Checked = False
    End Sub

    Private Sub NewRecordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewRecordToolStripMenuItem.Click
        resetForm()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MessageBox.Show("By Tan, Frederick B. ", "Contact Tracing App")
    End Sub

    Private Sub btnViewRecords_Click(sender As Object, e As EventArgs) Handles btnViewRecords.Click

        If (File.Exists(fileName)) Then
            Dim line As String = ""

            Dim inputFile As StreamReader = File.OpenText(fileName)
            While (Not inputFile.EndOfStream)
                line = inputFile.ReadLine() + vbNewLine
                rchTxtBxDisplayRecords.AppendText(line)
            End While
            inputFile.Close()
            btnViewRecords.Enabled = False
        Else
            MessageBox.Show("No Records has been save yet")
        End If

    End Sub

    Private Sub btnClearDisplay_Click(sender As Object, e As EventArgs) Handles btnClearDisplay.Click
        rchTxtBxDisplayRecords.Clear()
        btnViewRecords.Enabled = True

    End Sub
    Private Sub keyPress_Letters_Spaces_Numbers_Period(sender As Object, e As KeyPressEventArgs) Handles txtBxBarangay.KeyPress, txtBxMiddleName.KeyPress, txtBxLastName.KeyPress, txtBxFirstName.KeyPress
        If ((Not Char.IsLetter(e.KeyChar)) And (Not Char.IsControl(e.KeyChar)) And (Not Char.IsWhiteSpace(e.KeyChar)) And (Not Char.IsNumber(e.KeyChar) And Not (e.KeyChar.ToString() = "."))) Then

            e.Handled = True
        End If
    End Sub
    Private Sub keyPress_Numbers(sender As Object, e As KeyPressEventArgs) Handles txtBxContactNum.KeyPress, txtBxAge.KeyPress
        If ((Not Char.IsNumber(e.KeyChar)) And (Not Char.IsControl(e.KeyChar))) Then

            e.Handled = True
        End If
    End Sub

    Private Sub keyPres_EMail(sender As Object, e As KeyPressEventArgs) Handles txtBxEMail.KeyPress
        If ((Not Char.IsLetter(e.KeyChar)) And (Not Char.IsControl(e.KeyChar)) And (Not Char.IsWhiteSpace(e.KeyChar)) And (Not Char.IsNumber(e.KeyChar)) _
                And Not (e.KeyChar.ToString() = ".") And Not (e.KeyChar.ToString() = "@") And Not (e.KeyChar.ToString() = "_")) Then

            e.Handled = True
        End If
    End Sub

    Private Sub rchTxtBxDisplayRecords_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rchTxtBxDisplayRecords.KeyPress
        e.Handled = True
    End Sub

    Private Sub rchTxtBxDisplayRecords_KeyUp(sender As Object, e As KeyEventArgs) Handles rchTxtBxDisplayRecords.KeyUp
        e.Handled = True
    End Sub

    Private Sub rchTxtBxDisplayRecords_KeyDown(sender As Object, e As KeyEventArgs) Handles rchTxtBxDisplayRecords.KeyDown
        e.Handled = True
    End Sub


End Class
