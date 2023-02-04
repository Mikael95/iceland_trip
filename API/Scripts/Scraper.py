import requests
from bs4 import BeautifulSoup
import time
from selenium import webdriver


options = webdriver.ChromeOptions()
options.binary_location = "C:\Program Files\Google\Chrome\Application"
chrome_driver_binary = "./chromedriver.exe"
driver = webdriver.Chrome(chrome_driver_binary, chrome_options=options)

driver.get('https://booking.smyrilline.fo/en/book/multi-journey/journeySearch/')
time.sleep(5)

search_box = driver.find_element("name", "q")
search_box.send_keys('ChromeDriver')
search_box.submit()
