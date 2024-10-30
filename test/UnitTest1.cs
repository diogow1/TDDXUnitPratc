using app;

namespace test;

public class UnitTest1
{
    public Calculadora construirClasse()
    {
        string data = "20/02/2024";
        Calculadora calc = new Calculadora(data);
        return calc;
    }


    [Theory]
    [InlineData (1, 2, 3)]
    [InlineData (4, 5, 9)]
    public void TestSomar( int num1, int num2, int resultado)
    {

        // Arrange
        Calculadora calc = construirClasse();
        // Act
        int resultadoCalculadora = calc.Somar(num1, num2);
        // Arrange
        Assert.Equal(resultado, resultadoCalculadora);

    }


    [Theory]
    [InlineData (4, 2, 2)]
    [InlineData (5, 4, 1)]
    public void TestSubtrair( int num1, int num2, int resultado)
    {

        // Arrange
        Calculadora calc = construirClasse();
        // Act
        int resultadoCalculadora = calc.Subtrair(num1, num2);
        // Arrange
        Assert.Equal(resultado, resultadoCalculadora);
    }


    [Theory]
    [InlineData (1, 2, 2)]
    [InlineData (4, 5, 20)]
    public void TestMultiplicar( int num1, int num2, int resultado)
    {

        // Arrange
        Calculadora calc = construirClasse();
        // Act
        int resultadoCalculadora = calc.Multiplicar(num1, num2);
        // Arrange
        Assert.Equal(resultado, resultadoCalculadora);
    }


    [Theory]
    [InlineData (6, 2, 3)]
    [InlineData (4, 4, 1)]
    public void TestDividir( int num1, int num2, int resultado)
    {

        // Arrange
        Calculadora calc = construirClasse();
        // Act
        int resultadoCalculadora = calc.Dividir(num1, num2);
        // Arrange
        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Fact]
    public void TestarDivisaoPorZero()
    {
        // Arrage
        Calculadora calc = construirClasse();
        // Act // Arrange
        Assert.Throws<DivideByZeroException>(
            () => calc.Dividir(3,0)
        );
    }

    [Fact]
    public void TestarHistorico()
    {
        // Arrage
        Calculadora calc = construirClasse();

        // Act 
        calc.Somar(1, 2);
        calc.Dividir(4, 2);
        calc.Subtrair(3, 3);
        calc.Multiplicar(10, 5);
        var lista = calc.Historico();

        // Arrange
        Assert.NotEmpty(lista);
        Assert.Equal(3, lista.Count());
    }

}