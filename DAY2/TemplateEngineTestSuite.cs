using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateEngine.Tests
{
    public class TemplateEngineTestSuite
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Theju")]
        public void ShouldWorkForOneVariable(string value)
        {
            //Arrange
            TemplateEngine templateEngine = new TemplateEngine();
            templateEngine.setTemplate("Hello, {name}");
            templateEngine.setVariable("name", value);

            //Act
            string result = templateEngine.evaluate();

            //Assert
            Assert.That("Hello, "+ value, Is.EqualTo(result));
        }

        [TestCase("Theju", "Meghu")]
        public void ShouldWorkForOTwoVariable(string first, string last)
        {
            //Arrange
            TemplateEngine templateEngine = new TemplateEngine();
            templateEngine.setTemplate("Hello, {name}");
            templateEngine.setVariable("name", first + " " + last);

            //Act
            string result = templateEngine.evaluate();

            //Assert
            Assert.That("Hello, " + first + " " + last, Is.EqualTo(result));
        }

        [TestCase("Theju", "Meghu", "Developer")]
        public void ShouldWorkForNVariable(string first, string last, string title)
        {
            //Arrange
            TemplateEngine templateEngine = new TemplateEngine();
            templateEngine.setTemplate("Hello, {first} {last}, the {title}");
            templateEngine.setVariable("first", first);
            templateEngine.setVariable("last", last);
            templateEngine.setVariable("title", title);

            //Act
            string result = templateEngine.evaluate();

            //Assert
            Assert.That("Hello, " + first + " " + last + ", the " + title, Is.EqualTo(result));
        }
    }
}

