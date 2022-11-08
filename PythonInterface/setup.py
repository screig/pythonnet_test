import os
from setuptools import setup
# Get the requirements from reading the file.
dir_path = os.path.dirname(os.path.realpath(__file__))
with open(os.path.join(dir_path, 'requirements.txt'), 'r') as rq:
    req_list = rq.read().split('\n')
pkg_dependencies = [req for req in req_list if req.strip()]

# Define the package
setup(
    name='PythonInterface',
    version='1.0.0',
    package_dir={'': 'src'},
    package_data={'src': ['lib/*.dll', 'lib/x64/*.dll', 'lib/x86/*.dll']},
    include_package_data=True,
    install_requires=pkg_dependencies,
    classifiers=[
        'Programming Language :: Python',
        'Programming Language :: Python :: 3',
        'Programming Language :: Python :: 3.8',
    ]
)
