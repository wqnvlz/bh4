
import numpy as np
import pytesseract
import argparse
import cv2
from PIL import Image
import Levenshtein
import string
from nltk.corpus import stopwords
stopwords = stopwords.words('english')
from py_thesaurus import Thesaurus

def similarityScore(strlist, keywordlist):
    threshold = 4
    score = 0
    for word in strlist:
        for keyword1 in keywordlist:
            distance = Levenshtein.distance(word, keyword1)
            if distance<threshold:
                score += (threshold-distance)

    return score

def similarityScores(str, keywordlists):

    str = ''.join([word for word in str if word not in string.punctuation])
    str = str.lower()
    str = [word for word in str.split() if word not in stopwords]
    
    maxscore = 0
    whichindex = -1
    for keywordlistindex in range(len(keywordlists)):
        keywordlist = keywordlists[keywordlistindex]
        score = similarityScore(str, keywordlist)
        print(score)
        if score>maxscore:
            maxscore = score
            whichindex = keywordlistindex
    return whichindex

def enrich(keywords):
    newkeywords = keywords.copy()
    for keyword in keywords:
        thesaurus = Thesaurus(keyword)
        newkeywords.extend(thesaurus.get_synonym())
        newkeywords.extend(thesaurus.get_antonym())

    return newkeywords


print(Thesaurus("zero").get_synonym())
str = "Developing Efficient Algorithms Quiz Review "
keywordslist = [["Literature", "Style", "Essay"], ["algorithms", "efficiency", "Big-O"], ["Inhibit", "Zero", "Cells", "Coronavirus"]]
#keywordslist = [keywords for keywords in keywordslist]
keywordslist = [enrich(keywords) for keywords in keywordslist]
subjects = ["English", "Computer Science", "Biology", "Unknown"]
#print(subjects[similarityScores("nil die", keywordslist)])


cap = cv2.VideoCapture(1)
width = 640
height = 480

#period is time between checks
period = 300


while(True):

    cv2.waitKey(period)
    ret, frame = cap.read()
    gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
        
    text = pytesseract.image_to_string(gray)
    
    cv2.imshow('frame', gray)
    print(text)
    print(subjects[similarityScores(text, keywordslist)])
    if cv2.waitKey(1) and 0xFF == ord('q'):
        break

cap.release()
cv2.destroyAllWindows()

ap = argparse
