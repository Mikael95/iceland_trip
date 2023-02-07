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

browser.find_element("xpath", "//select[@id='j1_from-j1_from']/option[text()='Hirtshals']").click()
browser.find_element("xpath", "//select[@id='j2_from-j2_from']/option[text()='Tórshavn']").click()
browser.find_element("xpath", "//select[@id='j3_from-j3_from']/option[text()='Seyðisfjörður']").click()

browser.find_element("xpath", "//select[@id='j1_to-j1_to']/option[text()='Tórshavn']").click()
browser.find_element("xpath", "//select[@id='j2_to-j2_to']/option[text()='Seyðisfjörður']").click()
browser.find_element("xpath", "//select[@id='j3_to-j3_to']/option[text()='Hirtshals']").click()

browser.find_element("xpath", "//*[@class='cw-month-selector-container']").click()

month = browser.find_element("xpath", "//*[@class='cw-month-current']").text

while(month != "August"):
    browser.find_element("xpath", "//*[@class='cw-month-next']").click()
    month = browser.find_element("xpath", "//*[@class='cw-month-current']").text
time.sleep(1)