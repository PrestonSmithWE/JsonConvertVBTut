Imports System
Imports System.Text.Json.Serialization
Imports Newtonsoft.Json

Module Program
        Sub  Main(args As String()) 
            
            ' async methods can only be awaited within an async function. 
            ' this code takes async function and gets its awaiter
        Dim awaiter = myMain.GetAwaiter()
            ' Run the function
        myMain()
            ' dont end the program until the function finishes
        While(not awaiter.IsCompleted)
            
        End While
        
     
    End Sub
    async Function myMain() As Task
        Dim json as String
        
        'create base url
        Dim url  = "https://api.karmak.io/ops/DataAccess/frw/"
        Dim view = "PartsCommitted"
        
        'initialize the httpclient with headers
        Dim httpclient = new System.Net.Http.HttpClient()
        httpclient.DefaultRequestHeaders.Add("KarmakAccountNumber","03900")
        httpclient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key","889692d78f4046099d5897ac831bbfeb")
       
        'make a request to the url and receive a HttpResponseMessage
        Dim  result = await httpclient.GetAsync(url+view)
        
        'asynchronously retrieve the json from the response as a string
        json = await result.Content.ReadAsStringAsync()
        
        'Printing the response json
        Console.WriteLine(json)
        
        'Deserialize the response to an object
        dim resp = JsonConvert.DeserializeObject(Of List(Of PartsCommitted))(json)
        
        'some weird code to output all the properties of the item at index 0
        For Each prop in resp.Item(0).GetType().GetProperties()
            Console.WriteLine(prop.Name & " - "& prop.GetValue(resp.Item(0)))
        Next

    End Function
End Module
Public Class PartsCommitted
    Public Property PartNumber As String
    Public Property CustomerID As Integer
    Public Property PartsInventoryDetailID As Integer
    Public Property SupplierID As Integer
    Public Property SupplierCode As String
    Public Property Description As String
    Public Property BranchID As Integer
    Public Property Branch As String
    Public Property CustomerNumber As String
    Public Property CompanyName As String
    Public Property CommittedDate As DateTime
    Public Property Quantity As Integer
    Public Property OrderNumber As String
    Public Property OrderID As Integer
    Public Property [Module] As String
    Public Property RequestingBranch As String
    Public Property SellingPrice As Double
    Public Property SellingCost As Double
    Public Property ExtendedReplacementCost As Double
    Public Property AverageCost As Double
    Public Property ExtendedAverageCost As Double
    Public Property ExtendedSellingPrice As Double
    Public Property PartType As String
    Public Property AssemblyPartNumber As Object
    Public Property IsAssemblyDetail As Boolean
    Public Property ProcessGUID As String
End Class
