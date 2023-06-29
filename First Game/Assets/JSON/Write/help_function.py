import os
import json
import gzip

def save_json(json_data, data_dir, gzip_save=False):
    os.makedirs(os.path.dirname(data_dir), exist_ok=True)
    if gzip_save:
        with gzip.open(data_dir, "wt", encoding="UTF-8") as json_file:
            json.dump(json_data, json_file, indent=2)
    else:
        with open(data_dir, "w", encoding="UTF-8") as json_file:
            json.dump(json_data, json_file, indent=2)


def read_json(data_dir, gzip_load=False):
    if gzip_load:
        with gzip.open(data_dir, "rt", encoding="UTF-8") as json_file:
            return json.load(json_file)
    else:
        with open(data_dir, "r", encoding="UTF-8") as json_file:
            return json.load(json_file)