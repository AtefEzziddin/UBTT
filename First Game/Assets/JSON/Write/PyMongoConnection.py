from pymongo import MongoClient
from help_function import read_json
import pymongo.errors
from urllib.parse import quote_plus

class PyMongoConnect:
    def __init__(self, config_data_dir: str):
        self.config_data = read_json(config_data_dir)
        db_name = self.config_data["Datenbank"]
        self.client = MongoClient(
            f'mongodb://{quote_plus(self.config_data["User"])}:{quote_plus(self.config_data["Passwort"])}@{self.config_data["Server"]}:{self.config_data["Port"]}')
        # self.db = self.client.get_database(self.config_data["Datenbank"])
        self.db = self.client[db_name]