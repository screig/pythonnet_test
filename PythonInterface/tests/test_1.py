import logging
from datetime import datetime
from src import PythonInterface as pyi

logger = logging.getLogger(__name__)

class Testing_Class:

    @classmethod
    def setup_class(cls):
        logger.info("Initialising the  Testing_Class class")

    @classmethod
    def teardown_class(cls):
        logger.warning("Tearing down the Testing_Class class")

    def test_get_time(self):
        logger.info("Get time")
        mytime = pyi.get_time()
        assert type(mytime) == datetime

    def test_get_names(self):
        logger.info("Get some names")
        names = pyi.get_names()
        assert isinstance(names, list)
