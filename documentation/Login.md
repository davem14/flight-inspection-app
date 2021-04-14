**More details about the 'Login':**

The login display appears at the beginning when we start the app. In this window we need to enter the files 'csv' and 'xml' which is needed for the app running. The paths of the files are transferred to the 'VM_Login', and using the classes 'FileHendler, XmlHandler' the data is processed. Next, the 'VM_Login' initializes the 'model' and transfers the flight's data by using the property File. Next, it initializes the 'MainWindow' and supplies the 'model' to the constructor.
