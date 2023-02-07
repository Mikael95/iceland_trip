import requests
from bs4 import BeautifulSoup
import time
from selenium import webdriver
from selenium.webdriver.firefox.firefox_binary import FirefoxBinary
from selenium.webdriver.firefox.options import Options

options = Options()
options.binary = FirefoxBinary("C:\\Program Files\\Mozilla Firefox\\firefox.exe")
options.set_preference("browser.download.folderList",2)
options.set_preference("browser.download.manager.showWhenStarting", False)
options.set_preference("browser.download.dir","/Data")
options.set_preference("browser.helperApps.neverAsk.saveToDisk", "application/octet-stream,application/vnd.ms-excel")
browser = webdriver.Firefox(options=options)

browser.get('https://booking.smyrilline.fo/en/book/multi-journey/journeySearch/')
time.sleep(5)