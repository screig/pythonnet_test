using log4net;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DemoConversion
{

    /// <summary>
    /// This will register all the encoders that we define to convert C# objects to Python objects.
    /// </summary>
    public class RegisterEncoders
    {
        private static ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static bool _has_been_registered = false;


        public static void register_python_encoders()
        {
            if (!_has_been_registered)
            {
                _log.Debug("Registering Python - Date Time Encoder");
                PyObjectConversions.RegisterEncoder(new DateTimeConversions());

                _log.Debug("Registering Python - List<string> Encoder");
                PyObjectConversions.RegisterEncoder(new ListStringConversions());   

                _has_been_registered = true;
            }
        } 
    }


    /// <summary>
    /// This class will convert C# DateTime variables to Python Datetime variables.
    /// </summary>
    public class DateTimeConversions : IPyObjectEncoder
    {
        bool IPyObjectEncoder.CanEncode(Type type)
        {
            return type == typeof(DateTime);
        }

        PyObject IPyObjectEncoder.TryEncode(object value)
        {
            using (var scope = Py.CreateScope())
            {
                scope.Import("datetime");
                DateTime x = (DateTime)value;            
                scope.Exec($"a = datetime.datetime({x:yyyy, M, d, H, m, s, ffffff})");
                return scope.Get("a");
            }
        }
    }


    /// <summary>
    /// This class will convert a C# list of strings to a Python list [] of strings.
    /// </summary>
    public class ListStringConversions : IPyObjectEncoder
    {
        bool IPyObjectEncoder.CanEncode(Type type)
        {
            return type == typeof(List<string>);
        }

        PyObject IPyObjectEncoder.TryEncode(object value)
        {
            using (var scope = Py.CreateScope())
            {
                scope.Exec($"a = []");
                var input = (List<string>)value;
                foreach (var item in input)
                    scope.Exec($"a.append('{item}')");  // {item}
                return scope.Get("a");
            }
        }
    }






}
