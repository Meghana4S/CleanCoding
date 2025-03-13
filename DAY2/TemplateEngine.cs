using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateEngine.Tests
{
    public class TemplateEngine
    {
        private String template;
        private String value;
        private readonly Dictionary<string, string> variables = new Dictionary<string, string>();

        public string evaluate()
        {
            string result = template;
            foreach (var variable in variables)
            {
                result = result.Replace("{" + variable.Key + "}", variable.Value);
            }
            return result;
        }

        public void setTemplate(string template)
        {
            this.template = template;
        }

        public void setVariable(string name, string value)
        {
            if (variables.ContainsKey(name))
            {
                variables[name] = value;
            }
            else
            {
                variables.Add(name, value);
            }
        }
    }
}
