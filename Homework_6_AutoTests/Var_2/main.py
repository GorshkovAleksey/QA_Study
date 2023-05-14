from selenium import webdriver
from selenium.webdriver.chrome.service import Service
from selenium.webdriver.common.by import By
import time

webDriverPath = "C:/Users/gorsh/Desktop/ТГУ_Тестировщик/chromedriver_win32"
service = Service(webDriverPath)
chromeDriver = webdriver.Chrome(service=service)

chromeDriver.get("https://idemo.bspb.ru/")
chromeDriver.set_window_size(1400, 800)
username = chromeDriver.find_element(By.NAME, "username")
time.sleep(1)
username.clear()
username.send_keys('demo')
password = chromeDriver.find_element(By.NAME, "password")
password.clear()
password.send_keys('demo')
chromeDriver.find_element(By.ID, "login-button").click()
time.sleep(1)
chromeDriver.find_element(By.ID, "login-otp-button").click()

settingsButton = chromeDriver.find_element(By.ID, "settings-button")
if settingsButton != None:
    print('Элемент "settings-button" на странице присутствует.')
else:
    print('Элемент "settings-button" на странице ОТСУТСТВУЕТ!')

time.sleep(3)