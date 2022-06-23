import json
import os
from flask import Flask, request, send_from_directory, session, redirect, url_for, render_template
from flask_socketio import SocketIO, emit
from hashlib import sha512
import urllib


app = Flask(__name__)

#session işlemleri-----------------------
app.config["SESSION_PERMANENT"] = True
app.config["SESSION_TYPE"] = "filesystem"
app.secret_key = "18360859018"

@app.route('/', methods=['POST','GET'])
def home():
    if request.method == "POST":
        sum = ""
        sum += "POST:<br>"
        for i in request.form:
            sum += i + ": " + request.form[i] + "<br>"
        print(sum.replace('<br>','\n'))
        return sum
    elif request.method == "GET":
        sum = ""
        sum += "GET:<br>"
        for i in request.args:
            sum += i + ": " + request.args[i] + "<br>"
        print(sum.replace('<br>','\n'))
        return sum

@app.route('/urun', methods=['POST','GET'])
def urun():
    if request.method == "POST":
        return json.dumps(
            {
                "UrunResim":"icons/muslum.jpg",
                "UrunAdi":"Müslüm Gürses - Sandık Plak",
                "IndirimsizFiyat":"54.99",
                "IndirimliFiyat":"44.99",
                "Stok":"120",
                "YoutubeUrl":"https://www.youtube.com/embed/lYNMQBKDhwg",
                "Hakkinda":"Müslüm Gürses Sandık Albümünden Şarkılar",
                "Kategori":"Plak"
            }
        , ensure_ascii=False).encode('utf-8')
    elif request.method == "GET":
        return json.dumps(
            {
                "UrunResim":"image1.jpg",
                "UrunAdi":"Müslüm Gürses - Sandık Plak",
                "IndirimsizFiyat":"54.99",
                "IndirimliFiyat":"44.99",
                "Stok":"120",
                "YoutubeUrl":"https://www.youtube.com/denemedeneme",
                "Hakkinda":"Müslüm Gürses Sandık Albümünden Şarkılar",
                "Kategori":"Plak"
            }
        , ensure_ascii=False).encode('utf-8')

@app.route('/urunler', methods=['POST','GET'])
def urunler():
    if request.method == "POST":
        return json.dumps(
            [
                {
                    "UrunResim":"icons/muslum.jpg",
                    "UrunAdi":"Müslüm Gürses - Sandık Plak",
                    "IndirimsizFiyat":"54.99",
                    "IndirimliFiyat":"44.99",
                    "Stok":"120",
                    "YoutubeUrl":"https://www.youtube.com/embed/lYNMQBKDhwg",
                    "Hakkinda":"Müslüm Gürses Sandık Albümünden Şarkılar",
                    "Kategori":"Plak"
                },
                {
                    "UrunResim":"icons/muslum.jpg",
                    "UrunAdi":"Müslüm Gürses - Sandık Plak",
                    "IndirimsizFiyat":"54.99",
                    "IndirimliFiyat":"44.99",
                    "Stok":"120",
                    "YoutubeUrl":"https://www.youtube.com/embed/lYNMQBKDhwg",
                    "Hakkinda":"Müslüm Gürses Sandık Albümünden Şarkılar",
                    "Kategori":"Plak"
                },
                {
                    "UrunResim":"icons/muslum.jpg",
                    "UrunAdi":"Müslüm Gürses - Sandık Plak",
                    "IndirimsizFiyat":"54.99",
                    "IndirimliFiyat":"44.99",
                    "Stok":"120",
                    "YoutubeUrl":"https://www.youtube.com/embed/lYNMQBKDhwg",
                    "Hakkinda":"Müslüm Gürses Sandık Albümünden Şarkılar",
                    "Kategori":"Plak"
                },
                {
                    "UrunResim":"icons/muslum.jpg",
                    "UrunAdi":"Müslüm Gürses - Sandık Plak",
                    "IndirimsizFiyat":"54.99",
                    "IndirimliFiyat":"44.99",
                    "Stok":"120",
                    "YoutubeUrl":"https://www.youtube.com/embed/lYNMQBKDhwg",
                    "Hakkinda":"Müslüm Gürses Sandık Albümünden Şarkılar",
                    "Kategori":"Plak"
                },
                {
                    "UrunResim":"icons/muslum.jpg",
                    "UrunAdi":"Müslüm Gürses - Sandık Plak",
                    "IndirimsizFiyat":"54.99",
                    "IndirimliFiyat":"44.99",
                    "Stok":"120",
                    "YoutubeUrl":"https://www.youtube.com/embed/lYNMQBKDhwg",
                    "Hakkinda":"Müslüm Gürses Sandık Albümünden Şarkılar",
                    "Kategori":"Plak"
                }
            ]
        , ensure_ascii=False).encode('utf-8')
    return "null"

@app.errorhandler(404)
def not_found(e):
    return str(e)

@app.errorhandler(500)
def not_found(e):
    return str(e)


if __name__ == "__main__":
    port = int(os.environ.get("PORT", 5000))
    app.run(host='0.0.0.0', port=port)

"@app\.route\('(.*)', m"