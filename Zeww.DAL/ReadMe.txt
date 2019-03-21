-There is a Generic Repo for methods all entities need: (GET, Update, Delete, etc.)-
-There is a IGeneric Repo interface to call those methods which is the portal for the other repositories to access
	the main functions all repos will share
-There is a repository for each class including the methods that can be applied to each entity
-