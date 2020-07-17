Option Strict On
Public Class frmCarInventory
#Region "Variable Declarations"
    ' Decalres a list of Car onjects called cars
    Dim cars As New List(Of Car)
    ' Declares a boolean variable called editMode and sets it to False
    Dim editMode As Boolean = False
    ' Declares a boolean variable called updatingData and sets it to False
    Dim updatingData As Boolean = False
    ' Declares a integer variable called currentlySelectedIndex and sets it to -1
    Dim currentlySelectedIndex As Integer = -1
#End Region

#Region "Event Handlers"
    ''' <summary>
    ''' Updates car data when user clicks enter
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnEnterClick(sender As Object, e As EventArgs) Handles btnEnter.Click
        ' Declares inputMake string and assigns it the value of cmbMake
        Dim inputMake As String = cmbMake.Text
        ' Declares inputModel string and assigns it the value of txtModel
        Dim inputModel As String = txtModel.Text
        ' Declares inputYear string and assigns it the value of cmbYear
        Dim inputYear As String = cmbYear.Text
        ' Declares inputPrice string and assigns it the value of txtPrice
        Dim inputPrice As String = txtPrice.Text
        ' Declares inputState string and assigns it the value of chkNew
        Dim inputState As Boolean = chkNew.Checked
        ' Declares a string called errors and assigns it the output of the Validation function
        Dim errors As String = Validation(inputMake, inputModel, inputYear, inputPrice)
        Dim car As Car

        ' If validation was succesful then the following code block runs
        If (String.IsNullOrEmpty(errors)) Then

            'If editMode is true the following code block runs
            If (editMode) Then
                ' Sets the make of the currently selected car to the value of inputMake
                cars(currentlySelectedIndex).Make = inputMake
                ' Sets the model of the currently selected car to the value of inputModel
                cars(currentlySelectedIndex).Model = inputModel
                ' Sets the year of the currently selected car to the value of inputYear
                cars(currentlySelectedIndex).Year = inputYear
                ' Sets the price of the currently selected car to the value of inputPrice
                cars(currentlySelectedIndex).Price = inputPrice
                ' Sets the state of the currently selected car to the value of inputState
                cars(currentlySelectedIndex).State = inputState

                ' Calls the UpdateCarList function
                UpdateCarList()
                ' Calls the ResetForm function
                ResetForm()

                ' Displays the message "Updated Car" to the output text box
                lblOutput.Text = "Updated Car"

                ' If editMode is False the following code block runs 
            Else
                ' Creats a new car object and assigns the values of the input control to its properties
                car = New Car(inputMake, inputModel, inputYear, inputPrice, inputState)
                ' Adds the car object to the cars list
                cars.Add(car)
                ' Calls the ResetForm function
                ResetForm()

                ' Displays the message "Added new Car" to the output text box
                lblOutput.Text = "Added new Car"

                ' Calls the UpdateCarList function
                UpdateCarList()
            End If

            ' If validation fails the following code block runs
        Else
            ' Sets the output lab text to the value of error
            lblOutput.Text = errors
        End If
    End Sub
    ''' <summary>
    ''' Exits the program
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnExitClick(sender As Object, e As EventArgs) Handles btnExit.Click
        ' Exits the application
        Application.Exit()
    End Sub
    ''' <summary>
    ''' Resets the form to its defualt state
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnResetClick(sender As Object, e As EventArgs) Handles btnReset.Click
        ' Calls the reset form function
        ResetForm()
    End Sub
    ''' <summary>
    ''' Sets the input controls to the values of the selected car
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ListSelectedIndexChanged(sender As Object, e As EventArgs) Handles lvCarList.SelectedIndexChanged
        ' If there is a care selected in the list view the following code block runs
        If (Not lvCarList.FocusedItem Is Nothing) Then
            ' Sets currentlySelectedIndex to the index of the selcted car
            currentlySelectedIndex = lvCarList.FocusedItem.Index
            ' Declares a new instance of the car class using the values of the currently selected car
            Dim car As Car = cars(currentlySelectedIndex)

            ' Sets editMode to true
            editMode = True

            ' sets the value of the make combo box to the value of the currently selected car make
            cmbMake.Text = car.Make
            ' sets the value of the model text box to the value of the currently selected car model
            txtModel.Text = car.Model
            ' sets the value of the year combo box to the value of the currently selected car year
            cmbYear.Text = car.Year
            ' sets the value of the price text box to the value of the currently selected car price
            txtPrice.Text = car.Price
            ' sets the valu of the New check box to the value of the currently selected car state
            chkNew.Checked = car.State

            ' Displays the message "Loaded Car data to update" to the output text box
            lblOutput.Text = "Loaded Car data to update"
        End If
    End Sub
    ''' <summary>
    ''' Stops the user from checking the check box in the list view
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param
    Private Sub LvCarListItemCheck(sender As Object, e As ItemCheckEventArgs) Handles lvCarList.ItemCheck
        ' If updatingData is false then the following code block runs
        If (Not updatingData) Then
            ' Sets the new check box value to the old one
            e.NewValue = e.CurrentValue
        End If
    End Sub
#End Region

#Region "Functions and Methods"
    ''' <summary>
    ''' Validates the data inputted by the user
    ''' </summary>
    ''' <param name="make">make of car</param>
    ''' <param name="model">model of car</param>
    ''' <param name="year">year of car</param>
    ''' <param name="price">price of car</param>
    ''' <returns></returns>
    Public Function Validation(make As String, model As String, year As String, price As String) As String
        ' Declares a string called errorMessage
        Dim errorMessage As String = String.Empty
        ' Declares an integer called numericYear
        Dim numericYear As Integer
        ' Declares a double called numericPrice
        Dim numericPrice As Double

        ' If make is empty the following code block runs
        If (String.IsNullOrEmpty(make)) Then
            ' Adds the message to the "Please select a valid make" to errorMessage
            errorMessage += "Please select a valid make" & Environment.NewLine
        End If
        ' If model is empty the following code block runs
        If (String.IsNullOrEmpty(model)) Then
            ' Adds the message to the "Please enter a valid model" to errorMessage
            errorMessage += "Please enter a valid model" & Environment.NewLine
        End If
        ' If year is numeric the following code block runs
        If (Integer.TryParse(year, numericYear)) Then
            ' If numericYear is not in the valid range
            If (numericYear < 1920 Or numericYear > 2020) Then
                ' Adds the message to the "Please enter a year within the valid range" to errorMessage
                errorMessage += "Please enter a year within the valid range" & Environment.NewLine
            End If
            ' If year is non numeric the following code block runs
        Else
            ' Adds the message to the "Please enter a valid year" to errorMessage
            errorMessage += "Please enter a valid year" & Environment.NewLine
        End If
        ' If price is numeric the following code block should 
        If (Double.TryParse(price, numericPrice)) Then
            ' If numeric is less than 0 the following code block runs
            If (numericPrice < 0) Then
                ' Adds the message to the "Please enter a price above zero" to errorMessage
                errorMessage += "Please enter a price above zero" & Environment.NewLine
            End If
            ' If price is non numeric the following code block runs
        Else
            ' Adds the message to the "Please enter a valid price" to errorMessage
            errorMessage += "Please enter a valid price" & Environment.NewLine
        End If

        ' returns the string errorMessage
        Return errorMessage
    End Function
    ''' <summary>
    ''' Resets the form to its default state
    ''' </summary>
    Private Sub ResetForm()
        ' Clears list view selection
        lvCarList.SelectedIndices.Clear()

        ' Sets value in make combo box to empty
        cmbMake.SelectedIndex = -1
        ' Sets the model text box to empty
        txtModel.Text = String.Empty
        ' Sets value in year combo box to empty
        cmbYear.SelectedIndex = -1
        ' Sets the price text box to empty
        txtPrice.Text = String.Empty
        ' Sets the new checkbox to unchecked
        chkNew.Checked = False

        editMode = False

        lblOutput.Text = "Reset Form"
    End Sub
    ''' <summary>
    ''' Updates the list view control on the form
    ''' </summary>
    Private Sub UpdateCarList()
        ' Declares ListViewItem called carListItem
        Dim carListItem As ListViewItem

        ' Changes updatingData to true
        updatingData = True
        ' Clears the list view control
        lvCarList.Items.Clear()

        ' For each loop going through each element in the cars list
        For Each car As Car In cars
            ' Instances a new carListItem
            carListItem = New ListViewItem()

            ' Adds checkbox to list view item
            carListItem.Checked = car.State
            ' Adds id to list view item
            carListItem.SubItems.Add(car.InternalId.ToString)
            ' Adds Make to list view item
            carListItem.SubItems.Add(car.Make)
            ' Adds Model to list view item
            carListItem.SubItems.Add(car.Model)
            ' Adds Year to list view item
            carListItem.SubItems.Add(car.Year)
            ' Adds Price to list view item
            carListItem.SubItems.Add(car.Price)

            ' Adds list view item to the list view
            lvCarList.Items.Add(carListItem)
        Next
        ' Sets updatingData to false
        updatingData = False

    End Sub
#End Region
End Class

