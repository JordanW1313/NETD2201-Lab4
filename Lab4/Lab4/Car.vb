Option Strict On
Public Class Car
#Region "Properties"
    ' Declares a string property called carMake and sets it as empty
    Private carMake As String = String.Empty
    ' Declares a string property called carModel and sets it as empty
    Private carModel As String = String.Empty
    ' Declares a string property called carYear and sets it as empty
    Private carYear As String = String.Empty
    ' Declares a string property called carPrice and sets it as empty
    Private carPrice As String = String.Empty
    ' Declares a boolean property called carState and sets it as False
    Private carState As Boolean = False
    ' Declares a integer property called carInternalId and sets it to -1
    Private carInternalId As Integer = -1
    ' Declares a integer property called carMake and sets it to 0
    Shared carCount As Integer = 0
#End Region

#Region "Constructors"
    ''' <summary>
    ''' Parameterized constructor for the Car class
    ''' </summary>
    ''' <param name="make">Make propery of Car object</param>
    ''' <param name="model">Model propery of Car object</param>
    ''' <param name="year">Year propery of Car object</param>
    ''' <param name="price">Price propery of Car object</param>
    ''' <param name="state">State propery of Car object</param>
    Public Sub New(make As String, model As String, year As String, price As String, state As Boolean)
        ' Calls default car constructor
        Me.New()
        'Sets the carMake property of current car to make parameter 
        Me.carMake = make
        'Sets the carModel property of current car to model parameter
        Me.carModel = model
        'Sets the carYear property of current car to year parameter
        Me.carYear = year
        'Sets the carPrice property of current car to price parameter
        Me.carPrice = price
        'Sets the carState property of current car to state parameter
        Me.carState = state
    End Sub
    ''' <summary>
    ''' Default constructor for the car class
    ''' </summary>
    Public Sub New()
        ' Increments carCount variable by 1
        carCount += 1
        ' Sets carInternalId to the value od carCount
        carInternalId = carCount

    End Sub
#End Region

#Region "Property Methods"
    ''' <summary>
    ''' Gets or sets the carMake property
    ''' </summary>
    ''' <returns></returns>
    Public Property Make() As String
        ' Start of Get statement
        Get
            ' Returns value of carMake
            Return carMake
        End Get
        ' Start of Set statement
        Set(ByVal value As String)
            ' Sets value of carMake to passed in value
            carMake = value
        End Set
    End Property
    ''' <summary>
    ''' Gets or sets the carModel property
    ''' </summary>
    ''' <returns></returns>
    Public Property Model() As String
        ' Start of Get statement
        Get
            ' Returns value of carModel
            Return carModel
        End Get
        ' Start of Set statement
        Set(ByVal value As String)
            ' Sets value of carModel to passed in value
            carModel = value
        End Set
    End Property
    ''' <summary>
    ''' Gets or sets the carYear property
    ''' </summary>
    ''' <returns></returns>
    Public Property Year() As String
        ' Start of Get statement
        Get
            ' Returns value of carYear
            Return carYear
        End Get
        ' Start of Set statement
        Set(ByVal value As String)
            ' Sets value of carYear to passed in value
            carYear = value
        End Set
    End Property
    ''' <summary>
    ''' Gets or sets the carPrice property
    ''' </summary>
    ''' <returns></returns>
    Public Property Price() As String
        ' Start of Get statement
        Get
            ' Returns value of carPrice
            Return carPrice
        End Get
        ' Start of Set statement
        Set(ByVal value As String)
            ' Sets value of carPrice to passed in value
            carPrice = value
        End Set
    End Property
    ''' <summary>
    ''' Gets or sets the carState property
    ''' </summary>
    ''' <returns></returns>
    Public Property State() As Boolean
        ' Start of Get statement
        Get
            ' Returns value of carState
            Return carState
        End Get
        ' Start of Set statement
        Set(ByVal value As Boolean)
            ' Sets value of carState to passed in value
            carState = value
        End Set
    End Property
    ''' <summary>
    ''' Gets the carInternalId property
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property InternalId() As Integer
        ' Start of Get statement
        Get
            ' Returns value of carInternalId
            Return carInternalId
        End Get
    End Property
    ''' <summary>
    ''' Gets the carCount property
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Count() As Integer
        ' Start of Get statement
        Get
            ' Returns value of carCount
            Return carCount
        End Get
    End Property
#End Region
End Class