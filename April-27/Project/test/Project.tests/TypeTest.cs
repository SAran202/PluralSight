using System;
using Xunit;
namespace Project.tests{
public delegate string WriteLogDelegate(string logMessage);
public class TypeTests{

    [Fact]
    public void WriteLogDelegateCanPointToMethod(){
        WriteLogDelegate log;

        log=ReturnMessage;

        var result=log("Hello");
        Assert.Equal("Hello",result);
    }
    string ReturnMessage(string Message){
        return Message;
    }

    [Fact]
    public void valueTypeAlsoPassByValue(){
    var x=GetInt();
    SetInt(ref x);

    Assert.Equal(42,x);
    }
    private void SetInt(ref Int32 z){
    z = 42;
    }
    private int GetInt(){
    return 3;
    }
    [Fact]
    public void CSharpCanPassByRef(){
        var book1=GetBook("Book 1");
        GetBookSetName(book1,"New Name");

        Assert.Equal("New Name",book1.Name);
    }
    private void GetBookSetName(out Book book,string name){
        book=new Book(name);
    }
    [Fact]
    public void CSharpCanPassByValue(){
        var book1 = GetBook("Book 1");
        SetName(book1,"new Name");

        Assert.Equal("Book 1",book1.Name);
    }
    private void GetBookSetName(Book book,string name){
        book=new Book(name);
    }
    [Fact]
    public void CanSetNameFromReference(){
        var book1=GetBook("Book 1");
        SetName(book1,"New Name");

        Assert.Equal("New Name",book1.Name);
    }
    private void SetName(Book book,string name){
        book.Name=name;
    }
    [Fact]
    public void StringsBehaveLikeValueTypes(){
        string name="Scott";
        var upper=MakeUppercase(name);

        Assert.Equal("SCOOT",name);
    }
    private string MakeUppercase(string parameter){
        return parameter.ToUpper();
    }
    [Fact]
    public void GetBookReturnsDifferentObjects(){
        var book1=GetBook("Book 1");
        var book2=GetBook("Book 2");

        Assert.Equal("Book 1",book1.Name);
        Assert.Equal("Book 2",book2.Name);
        Assert.NotSame(book1,book2);
    }
    [Fact]
    public void TwoVarsCanReferenceSameObject(){
        var book1=GetBook("Book 1");
        var book2=book1;

        Assert.Same(book1,book2);
        Assert.True(Object.ReferenceEquals(book1,book2));
    }
    Book GetBook(string name){
        return new Book(name);
    }
}
}