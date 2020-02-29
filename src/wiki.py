from rake_nltk import Rake
import wikipedia


def getFromWiki(word):
    page = wikipedia.page(word)
    stuff=page.summary
    # print(stuff)
    r=Rake()
    r.extract_keywords_from_text(stuff)
    ret=r.get_ranked_phrases()
    return ret
