import logging
import os
import sys
import clr

path = r'%s%s' % ('lib/', 'DemoConversion')          # Import our C# assembly, first make a relative path
sys.path.append(os.path.dirname(__file__))           # We add the directory of this file to the path
clr.AddReference(path)                               # Import the C# assembly in to Python

# Import the C# namespace
from DemoConversion import *                         # This can be read as import from <DLL_NAME> the <C# Namespace>

# Start the Python logger.
logger = logging.getLogger(__name__)


def get_time():
    """
    Get the current UTC time from C#
    """
    return SomeClass.get_current_time()


def get_names():
    """
    Get a list of all the market codes the library uses.
    """
    return SomeClass.get_names()





